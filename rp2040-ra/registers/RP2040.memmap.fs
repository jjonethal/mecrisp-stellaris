\ Forth Memory Map file for RP2040
\ Copyright Terry Porter 2021 "terry@tjporter.com.au" 
\ MIT Licensed 

\ =========================== XIP_CTRL =========================== \
$14000000 constant XIP_CTRL_CTRL \ Cache control
$14000004 constant XIP_CTRL_FLUSH \ Cache Flush control
$14000008 constant XIP_CTRL_STAT \ Cache Status
$1400000C constant XIP_CTRL_CTR_HIT \ Cache Hit counter  A 32 bit saturating counter that increments upon each cache hit,  i.e. when an XIP access is serviced directly from cached data.  Write any value to clear.
$14000010 constant XIP_CTRL_CTR_ACC \ Cache Access counter  A 32 bit saturating counter that increments upon each XIP access,  whether the cache is hit or not. This includes noncacheable accesses.  Write any value to clear.
$14000014 constant XIP_CTRL_STREAM_ADDR \ FIFO stream address
$14000018 constant XIP_CTRL_STREAM_CTR \ FIFO stream control
$1400001C constant XIP_CTRL_STREAM_FIFO \ FIFO stream data  Streamed data is buffered here, for retrieval by the system DMA.  This FIFO can also be accessed via the XIP_AUX slave, to avoid exposing  the DMA to bus stalls caused by other XIP traffic.

\ =========================== XIP_SSI =========================== \
$18000000 constant XIP_SSI_CTRLR0 \ Control register 0
$18000004 constant XIP_SSI_CTRLR1 \ Master Control register 1
$18000008 constant XIP_SSI_SSIENR \ SSI Enable
$1800000C constant XIP_SSI_MWCR \ Microwire Control
$18000010 constant XIP_SSI_SER \ Slave enable
$18000014 constant XIP_SSI_BAUDR \ Baud rate
$18000018 constant XIP_SSI_TXFTLR \ TX FIFO threshold level
$1800001C constant XIP_SSI_RXFTLR \ RX FIFO threshold level
$18000020 constant XIP_SSI_TXFLR \ TX FIFO level
$18000024 constant XIP_SSI_RXFLR \ RX FIFO level
$18000028 constant XIP_SSI_SR \ Status register
$1800002C constant XIP_SSI_IMR \ Interrupt mask
$18000030 constant XIP_SSI_ISR \ Interrupt status
$18000034 constant XIP_SSI_RISR \ Raw interrupt status
$18000038 constant XIP_SSI_TXOICR \ TX FIFO overflow interrupt clear
$1800003C constant XIP_SSI_RXOICR \ RX FIFO overflow interrupt clear
$18000040 constant XIP_SSI_RXUICR \ RX FIFO underflow interrupt clear
$18000044 constant XIP_SSI_MSTICR \ Multi-master interrupt clear
$18000048 constant XIP_SSI_ICR \ Interrupt clear
$1800004C constant XIP_SSI_DMACR \ DMA control
$18000050 constant XIP_SSI_DMATDLR \ DMA TX data level
$18000054 constant XIP_SSI_DMARDLR \ DMA RX data level
$18000058 constant XIP_SSI_IDR \ Identification register
$1800005C constant XIP_SSI_SSI_VERSION_ID \ Version ID
$18000060 constant XIP_SSI_DR0 \ Data Register 0 of 36
$180000F0 constant XIP_SSI_RX_SAMPLE_DLY \ RX sample delay
$180000F4 constant XIP_SSI_SPI_CTRLR0 \ SPI control
$180000F8 constant XIP_SSI_TXD_DRIVE_EDGE \ TX drive edge

\ =========================== SYSINFO =========================== \
$40000000 constant SYSINFO_CHIP_ID \ JEDEC JEP-106 compliant chip identifier.
$40000004 constant SYSINFO_PLATFORM \ Platform register. Allows software to know what environment it is running in.
$40000040 constant SYSINFO_GITREF_RP2040 \ Git hash of the chip source. Used to identify chip version.

\ =========================== SYSCFG =========================== \
$40004000 constant SYSCFG_PROC0_NMI_MASK \ Processor core 0 NMI source mask  Set a bit high to enable NMI from that IRQ
$40004004 constant SYSCFG_PROC1_NMI_MASK \ Processor core 1 NMI source mask  Set a bit high to enable NMI from that IRQ
$40004008 constant SYSCFG_PROC_CONFIG \ Configuration for processors
$4000400C constant SYSCFG_PROC_IN_SYNC_BYPASS \ For each bit, if 1, bypass the input synchronizer between that GPIO  and the GPIO input register in the SIO. The input synchronizers should  generally be unbypassed, to avoid injecting metastabilities into processors.  If you're feeling brave, you can bypass to save two cycles of input  latency. This register applies to GPIO 0...29.
$40004010 constant SYSCFG_PROC_IN_SYNC_BYPASS_HI \ For each bit, if 1, bypass the input synchronizer between that GPIO  and the GPIO input register in the SIO. The input synchronizers should  generally be unbypassed, to avoid injecting metastabilities into processors.  If you're feeling brave, you can bypass to save two cycles of input  latency. This register applies to GPIO 30...35 the QSPI IOs.
$40004014 constant SYSCFG_DBGFORCE \ Directly control the SWD debug port of either processor
$40004018 constant SYSCFG_MEMPOWERDOWN \ Control power downs to memories. Set high to power down memories.  Use with extreme caution

\ =========================== CLOCKS =========================== \
$40008000 constant CLOCKS_CLK_GPOUT0_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008004 constant CLOCKS_CLK_GPOUT0_DIV \ Clock divisor, can be changed on-the-fly
$40008008 constant CLOCKS_CLK_GPOUT0_SELECTED \ Indicates which src is currently selected one-hot
$4000800C constant CLOCKS_CLK_GPOUT1_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008010 constant CLOCKS_CLK_GPOUT1_DIV \ Clock divisor, can be changed on-the-fly
$40008014 constant CLOCKS_CLK_GPOUT1_SELECTED \ Indicates which src is currently selected one-hot
$40008018 constant CLOCKS_CLK_GPOUT2_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$4000801C constant CLOCKS_CLK_GPOUT2_DIV \ Clock divisor, can be changed on-the-fly
$40008020 constant CLOCKS_CLK_GPOUT2_SELECTED \ Indicates which src is currently selected one-hot
$40008024 constant CLOCKS_CLK_GPOUT3_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008028 constant CLOCKS_CLK_GPOUT3_DIV \ Clock divisor, can be changed on-the-fly
$4000802C constant CLOCKS_CLK_GPOUT3_SELECTED \ Indicates which src is currently selected one-hot
$40008030 constant CLOCKS_CLK_REF_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008034 constant CLOCKS_CLK_REF_DIV \ Clock divisor, can be changed on-the-fly
$40008038 constant CLOCKS_CLK_REF_SELECTED \ Indicates which src is currently selected one-hot
$4000803C constant CLOCKS_CLK_SYS_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008040 constant CLOCKS_CLK_SYS_DIV \ Clock divisor, can be changed on-the-fly
$40008044 constant CLOCKS_CLK_SYS_SELECTED \ Indicates which src is currently selected one-hot
$40008048 constant CLOCKS_CLK_PERI_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008050 constant CLOCKS_CLK_PERI_SELECTED \ Indicates which src is currently selected one-hot
$40008054 constant CLOCKS_CLK_USB_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008058 constant CLOCKS_CLK_USB_DIV \ Clock divisor, can be changed on-the-fly
$4000805C constant CLOCKS_CLK_USB_SELECTED \ Indicates which src is currently selected one-hot
$40008060 constant CLOCKS_CLK_ADC_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008064 constant CLOCKS_CLK_ADC_DIV \ Clock divisor, can be changed on-the-fly
$40008068 constant CLOCKS_CLK_ADC_SELECTED \ Indicates which src is currently selected one-hot
$4000806C constant CLOCKS_CLK_RTC_CTRL \ Clock control, can be changed on-the-fly except for auxsrc
$40008070 constant CLOCKS_CLK_RTC_DIV \ Clock divisor, can be changed on-the-fly
$40008074 constant CLOCKS_CLK_RTC_SELECTED \ Indicates which src is currently selected one-hot
$40008078 constant CLOCKS_CLK_SYS_RESUS_CTRL \ 
$4000807C constant CLOCKS_CLK_SYS_RESUS_STATUS \ 
$40008080 constant CLOCKS_FC0_REF_KHZ \ Reference clock frequency in kHz
$40008084 constant CLOCKS_FC0_MIN_KHZ \ Minimum pass frequency in kHz. This is optional. Set to 0 if you are not using the pass/fail flags
$40008088 constant CLOCKS_FC0_MAX_KHZ \ Maximum pass frequency in kHz. This is optional. Set to $1ffffff if you are not using the pass/fail flags
$4000808C constant CLOCKS_FC0_DELAY \ Delays the start of frequency counting to allow the mux to settle  Delay is measured in multiples of the reference clock period
$40008090 constant CLOCKS_FC0_INTERVAL \ The test interval is 0.98us * 2**interval, but let's call it 1us * 2**interval  The default gives a test interval of 250us
$40008094 constant CLOCKS_FC0_SRC \ Clock sent to frequency counter, set to 0 when not required  Writing to this register initiates the frequency count
$40008098 constant CLOCKS_FC0_STATUS \ Frequency counter status
$4000809C constant CLOCKS_FC0_RESULT \ Result of frequency measurement, only valid when status_done=1
$400080A0 constant CLOCKS_WAKE_EN0 \ enable clock in wake mode
$400080A4 constant CLOCKS_WAKE_EN1 \ enable clock in wake mode
$400080A8 constant CLOCKS_SLEEP_EN0 \ enable clock in sleep mode
$400080AC constant CLOCKS_SLEEP_EN1 \ enable clock in sleep mode
$400080B0 constant CLOCKS_ENABLED0 \ indicates the state of the clock enable
$400080B4 constant CLOCKS_ENABLED1 \ indicates the state of the clock enable
$400080B8 constant CLOCKS_INTR \ Raw Interrupts
$400080BC constant CLOCKS_INTE \ Interrupt Enable
$400080C0 constant CLOCKS_INTF \ Interrupt Force
$400080C4 constant CLOCKS_INTS \ Interrupt status after masking & forcing

\ =========================== RESETS =========================== \
$4000C000 constant RESETS_RESET \ Reset control. If a bit is set it means the peripheral is in reset. 0 means the peripheral's reset is deasserted.
$4000C004 constant RESETS_WDSEL \ Watchdog select. If a bit is set then the watchdog will reset this peripheral when the watchdog fires.
$4000C008 constant RESETS_RESET_DONE \ Reset done. If a bit is set then a reset done signal has been returned by the peripheral. This indicates that the peripheral's registers are ready to be accessed.

\ =========================== PSM =========================== \
$40010000 constant PSM_FRCE_ON \ Force block out of reset i.e. power it on
$40010004 constant PSM_FRCE_OFF \ Force into reset i.e. power it off
$40010008 constant PSM_WDSEL \ Set to 1 if this peripheral should be reset when the watchdog fires.
$4001000C constant PSM_DONE \ Indicates the peripheral's registers are ready to access.

\ =========================== IO_BANK0 =========================== \
$40014000 constant IO_BANK0_GPIO0_STATUS \ GPIO status
$40014004 constant IO_BANK0_GPIO0_CTRL \ GPIO control including function select and overrides.
$40014008 constant IO_BANK0_GPIO1_STATUS \ GPIO status
$4001400C constant IO_BANK0_GPIO1_CTRL \ GPIO control including function select and overrides.
$40014010 constant IO_BANK0_GPIO2_STATUS \ GPIO status
$40014014 constant IO_BANK0_GPIO2_CTRL \ GPIO control including function select and overrides.
$40014018 constant IO_BANK0_GPIO3_STATUS \ GPIO status
$4001401C constant IO_BANK0_GPIO3_CTRL \ GPIO control including function select and overrides.
$40014020 constant IO_BANK0_GPIO4_STATUS \ GPIO status
$40014024 constant IO_BANK0_GPIO4_CTRL \ GPIO control including function select and overrides.
$40014028 constant IO_BANK0_GPIO5_STATUS \ GPIO status
$4001402C constant IO_BANK0_GPIO5_CTRL \ GPIO control including function select and overrides.
$40014030 constant IO_BANK0_GPIO6_STATUS \ GPIO status
$40014034 constant IO_BANK0_GPIO6_CTRL \ GPIO control including function select and overrides.
$40014038 constant IO_BANK0_GPIO7_STATUS \ GPIO status
$4001403C constant IO_BANK0_GPIO7_CTRL \ GPIO control including function select and overrides.
$40014040 constant IO_BANK0_GPIO8_STATUS \ GPIO status
$40014044 constant IO_BANK0_GPIO8_CTRL \ GPIO control including function select and overrides.
$40014048 constant IO_BANK0_GPIO9_STATUS \ GPIO status
$4001404C constant IO_BANK0_GPIO9_CTRL \ GPIO control including function select and overrides.
$40014050 constant IO_BANK0_GPIO10_STATUS \ GPIO status
$40014054 constant IO_BANK0_GPIO10_CTRL \ GPIO control including function select and overrides.
$40014058 constant IO_BANK0_GPIO11_STATUS \ GPIO status
$4001405C constant IO_BANK0_GPIO11_CTRL \ GPIO control including function select and overrides.
$40014060 constant IO_BANK0_GPIO12_STATUS \ GPIO status
$40014064 constant IO_BANK0_GPIO12_CTRL \ GPIO control including function select and overrides.
$40014068 constant IO_BANK0_GPIO13_STATUS \ GPIO status
$4001406C constant IO_BANK0_GPIO13_CTRL \ GPIO control including function select and overrides.
$40014070 constant IO_BANK0_GPIO14_STATUS \ GPIO status
$40014074 constant IO_BANK0_GPIO14_CTRL \ GPIO control including function select and overrides.
$40014078 constant IO_BANK0_GPIO15_STATUS \ GPIO status
$4001407C constant IO_BANK0_GPIO15_CTRL \ GPIO control including function select and overrides.
$40014080 constant IO_BANK0_GPIO16_STATUS \ GPIO status
$40014084 constant IO_BANK0_GPIO16_CTRL \ GPIO control including function select and overrides.
$40014088 constant IO_BANK0_GPIO17_STATUS \ GPIO status
$4001408C constant IO_BANK0_GPIO17_CTRL \ GPIO control including function select and overrides.
$40014090 constant IO_BANK0_GPIO18_STATUS \ GPIO status
$40014094 constant IO_BANK0_GPIO18_CTRL \ GPIO control including function select and overrides.
$40014098 constant IO_BANK0_GPIO19_STATUS \ GPIO status
$4001409C constant IO_BANK0_GPIO19_CTRL \ GPIO control including function select and overrides.
$400140A0 constant IO_BANK0_GPIO20_STATUS \ GPIO status
$400140A4 constant IO_BANK0_GPIO20_CTRL \ GPIO control including function select and overrides.
$400140A8 constant IO_BANK0_GPIO21_STATUS \ GPIO status
$400140AC constant IO_BANK0_GPIO21_CTRL \ GPIO control including function select and overrides.
$400140B0 constant IO_BANK0_GPIO22_STATUS \ GPIO status
$400140B4 constant IO_BANK0_GPIO22_CTRL \ GPIO control including function select and overrides.
$400140B8 constant IO_BANK0_GPIO23_STATUS \ GPIO status
$400140BC constant IO_BANK0_GPIO23_CTRL \ GPIO control including function select and overrides.
$400140C0 constant IO_BANK0_GPIO24_STATUS \ GPIO status
$400140C4 constant IO_BANK0_GPIO24_CTRL \ GPIO control including function select and overrides.
$400140C8 constant IO_BANK0_GPIO25_STATUS \ GPIO status
$400140CC constant IO_BANK0_GPIO25_CTRL \ GPIO control including function select and overrides.
$400140D0 constant IO_BANK0_GPIO26_STATUS \ GPIO status
$400140D4 constant IO_BANK0_GPIO26_CTRL \ GPIO control including function select and overrides.
$400140D8 constant IO_BANK0_GPIO27_STATUS \ GPIO status
$400140DC constant IO_BANK0_GPIO27_CTRL \ GPIO control including function select and overrides.
$400140E0 constant IO_BANK0_GPIO28_STATUS \ GPIO status
$400140E4 constant IO_BANK0_GPIO28_CTRL \ GPIO control including function select and overrides.
$400140E8 constant IO_BANK0_GPIO29_STATUS \ GPIO status
$400140EC constant IO_BANK0_GPIO29_CTRL \ GPIO control including function select and overrides.
$400140F0 constant IO_BANK0_INTR0 \ Raw Interrupts
$400140F4 constant IO_BANK0_INTR1 \ Raw Interrupts
$400140F8 constant IO_BANK0_INTR2 \ Raw Interrupts
$400140FC constant IO_BANK0_INTR3 \ Raw Interrupts
$40014100 constant IO_BANK0_PROC0_INTE0 \ Interrupt Enable for proc0
$40014104 constant IO_BANK0_PROC0_INTE1 \ Interrupt Enable for proc0
$40014108 constant IO_BANK0_PROC0_INTE2 \ Interrupt Enable for proc0
$4001410C constant IO_BANK0_PROC0_INTE3 \ Interrupt Enable for proc0
$40014110 constant IO_BANK0_PROC0_INTF0 \ Interrupt Force for proc0
$40014114 constant IO_BANK0_PROC0_INTF1 \ Interrupt Force for proc0
$40014118 constant IO_BANK0_PROC0_INTF2 \ Interrupt Force for proc0
$4001411C constant IO_BANK0_PROC0_INTF3 \ Interrupt Force for proc0
$40014120 constant IO_BANK0_PROC0_INTS0 \ Interrupt status after masking & forcing for proc0
$40014124 constant IO_BANK0_PROC0_INTS1 \ Interrupt status after masking & forcing for proc0
$40014128 constant IO_BANK0_PROC0_INTS2 \ Interrupt status after masking & forcing for proc0
$4001412C constant IO_BANK0_PROC0_INTS3 \ Interrupt status after masking & forcing for proc0
$40014130 constant IO_BANK0_PROC1_INTE0 \ Interrupt Enable for proc1
$40014134 constant IO_BANK0_PROC1_INTE1 \ Interrupt Enable for proc1
$40014138 constant IO_BANK0_PROC1_INTE2 \ Interrupt Enable for proc1
$4001413C constant IO_BANK0_PROC1_INTE3 \ Interrupt Enable for proc1
$40014140 constant IO_BANK0_PROC1_INTF0 \ Interrupt Force for proc1
$40014144 constant IO_BANK0_PROC1_INTF1 \ Interrupt Force for proc1
$40014148 constant IO_BANK0_PROC1_INTF2 \ Interrupt Force for proc1
$4001414C constant IO_BANK0_PROC1_INTF3 \ Interrupt Force for proc1
$40014150 constant IO_BANK0_PROC1_INTS0 \ Interrupt status after masking & forcing for proc1
$40014154 constant IO_BANK0_PROC1_INTS1 \ Interrupt status after masking & forcing for proc1
$40014158 constant IO_BANK0_PROC1_INTS2 \ Interrupt status after masking & forcing for proc1
$4001415C constant IO_BANK0_PROC1_INTS3 \ Interrupt status after masking & forcing for proc1
$40014160 constant IO_BANK0_DORMANT_WAKE_INTE0 \ Interrupt Enable for dormant_wake
$40014164 constant IO_BANK0_DORMANT_WAKE_INTE1 \ Interrupt Enable for dormant_wake
$40014168 constant IO_BANK0_DORMANT_WAKE_INTE2 \ Interrupt Enable for dormant_wake
$4001416C constant IO_BANK0_DORMANT_WAKE_INTE3 \ Interrupt Enable for dormant_wake
$40014170 constant IO_BANK0_DORMANT_WAKE_INTF0 \ Interrupt Force for dormant_wake
$40014174 constant IO_BANK0_DORMANT_WAKE_INTF1 \ Interrupt Force for dormant_wake
$40014178 constant IO_BANK0_DORMANT_WAKE_INTF2 \ Interrupt Force for dormant_wake
$4001417C constant IO_BANK0_DORMANT_WAKE_INTF3 \ Interrupt Force for dormant_wake
$40014180 constant IO_BANK0_DORMANT_WAKE_INTS0 \ Interrupt status after masking & forcing for dormant_wake
$40014184 constant IO_BANK0_DORMANT_WAKE_INTS1 \ Interrupt status after masking & forcing for dormant_wake
$40014188 constant IO_BANK0_DORMANT_WAKE_INTS2 \ Interrupt status after masking & forcing for dormant_wake
$4001418C constant IO_BANK0_DORMANT_WAKE_INTS3 \ Interrupt status after masking & forcing for dormant_wake

\ =========================== IO_QSPI =========================== \
$40018000 constant IO_QSPI_GPIO_QSPI_SCLK_STATUS \ GPIO status
$40018004 constant IO_QSPI_GPIO_QSPI_SCLK_CTRL \ GPIO control including function select and overrides.
$40018008 constant IO_QSPI_GPIO_QSPI_SS_STATUS \ GPIO status
$4001800C constant IO_QSPI_GPIO_QSPI_SS_CTRL \ GPIO control including function select and overrides.
$40018010 constant IO_QSPI_GPIO_QSPI_SD0_STATUS \ GPIO status
$40018014 constant IO_QSPI_GPIO_QSPI_SD0_CTRL \ GPIO control including function select and overrides.
$40018018 constant IO_QSPI_GPIO_QSPI_SD1_STATUS \ GPIO status
$4001801C constant IO_QSPI_GPIO_QSPI_SD1_CTRL \ GPIO control including function select and overrides.
$40018020 constant IO_QSPI_GPIO_QSPI_SD2_STATUS \ GPIO status
$40018024 constant IO_QSPI_GPIO_QSPI_SD2_CTRL \ GPIO control including function select and overrides.
$40018028 constant IO_QSPI_GPIO_QSPI_SD3_STATUS \ GPIO status
$4001802C constant IO_QSPI_GPIO_QSPI_SD3_CTRL \ GPIO control including function select and overrides.
$40018030 constant IO_QSPI_INTR \ Raw Interrupts
$40018034 constant IO_QSPI_PROC0_INTE \ Interrupt Enable for proc0
$40018038 constant IO_QSPI_PROC0_INTF \ Interrupt Force for proc0
$4001803C constant IO_QSPI_PROC0_INTS \ Interrupt status after masking & forcing for proc0
$40018040 constant IO_QSPI_PROC1_INTE \ Interrupt Enable for proc1
$40018044 constant IO_QSPI_PROC1_INTF \ Interrupt Force for proc1
$40018048 constant IO_QSPI_PROC1_INTS \ Interrupt status after masking & forcing for proc1
$4001804C constant IO_QSPI_DORMANT_WAKE_INTE \ Interrupt Enable for dormant_wake
$40018050 constant IO_QSPI_DORMANT_WAKE_INTF \ Interrupt Force for dormant_wake
$40018054 constant IO_QSPI_DORMANT_WAKE_INTS \ Interrupt status after masking & forcing for dormant_wake

\ =========================== PADS_BANK0 =========================== \
$4001C000 constant PADS_BANK0_VOLTAGE_SELECT \ Voltage select. Per bank control
$4001C004 constant PADS_BANK0_GPIO0 \ Pad control register
$4001C008 constant PADS_BANK0_GPIO1 \ Pad control register
$4001C00C constant PADS_BANK0_GPIO2 \ Pad control register
$4001C010 constant PADS_BANK0_GPIO3 \ Pad control register
$4001C014 constant PADS_BANK0_GPIO4 \ Pad control register
$4001C018 constant PADS_BANK0_GPIO5 \ Pad control register
$4001C01C constant PADS_BANK0_GPIO6 \ Pad control register
$4001C020 constant PADS_BANK0_GPIO7 \ Pad control register
$4001C024 constant PADS_BANK0_GPIO8 \ Pad control register
$4001C028 constant PADS_BANK0_GPIO9 \ Pad control register
$4001C02C constant PADS_BANK0_GPIO10 \ Pad control register
$4001C030 constant PADS_BANK0_GPIO11 \ Pad control register
$4001C034 constant PADS_BANK0_GPIO12 \ Pad control register
$4001C038 constant PADS_BANK0_GPIO13 \ Pad control register
$4001C03C constant PADS_BANK0_GPIO14 \ Pad control register
$4001C040 constant PADS_BANK0_GPIO15 \ Pad control register
$4001C044 constant PADS_BANK0_GPIO16 \ Pad control register
$4001C048 constant PADS_BANK0_GPIO17 \ Pad control register
$4001C04C constant PADS_BANK0_GPIO18 \ Pad control register
$4001C050 constant PADS_BANK0_GPIO19 \ Pad control register
$4001C054 constant PADS_BANK0_GPIO20 \ Pad control register
$4001C058 constant PADS_BANK0_GPIO21 \ Pad control register
$4001C05C constant PADS_BANK0_GPIO22 \ Pad control register
$4001C060 constant PADS_BANK0_GPIO23 \ Pad control register
$4001C064 constant PADS_BANK0_GPIO24 \ Pad control register
$4001C068 constant PADS_BANK0_GPIO25 \ Pad control register
$4001C06C constant PADS_BANK0_GPIO26 \ Pad control register
$4001C070 constant PADS_BANK0_GPIO27 \ Pad control register
$4001C074 constant PADS_BANK0_GPIO28 \ Pad control register
$4001C078 constant PADS_BANK0_GPIO29 \ Pad control register
$4001C07C constant PADS_BANK0_SWCLK \ Pad control register
$4001C080 constant PADS_BANK0_SWD \ Pad control register

\ =========================== PADS_QSPI =========================== \
$40020000 constant PADS_QSPI_VOLTAGE_SELECT \ Voltage select. Per bank control
$40020004 constant PADS_QSPI_GPIO_QSPI_SCLK \ Pad control register
$40020008 constant PADS_QSPI_GPIO_QSPI_SD0 \ Pad control register
$4002000C constant PADS_QSPI_GPIO_QSPI_SD1 \ Pad control register
$40020010 constant PADS_QSPI_GPIO_QSPI_SD2 \ Pad control register
$40020014 constant PADS_QSPI_GPIO_QSPI_SD3 \ Pad control register
$40020018 constant PADS_QSPI_GPIO_QSPI_SS \ Pad control register

\ =========================== XOSC =========================== \
$40024000 constant XOSC_CTRL \ Crystal Oscillator Control
$40024004 constant XOSC_STATUS \ Crystal Oscillator Status
$40024008 constant XOSC_DORMANT \ Crystal Oscillator pause control  This is used to save power by pausing the XOSC  On power-up this field is initialised to WAKE  An invalid write will also select WAKE  WARNING: stop the PLLs before selecting dormant mode  WARNING: setup the irq before selecting dormant mode
$4002400C constant XOSC_STARTUP \ Controls the startup delay
$4002401C constant XOSC_COUNT \ A down counter running at the xosc frequency which counts to zero and stops.  To start the counter write a non-zero value.  Can be used for short software pauses when setting up time sensitive hardware.

\ =========================== PLL_SYS =========================== \
$40028000 constant PLL_SYS_CS \ Control and Status  GENERAL CONSTRAINTS:  Reference clock frequency min=5MHz, max=800MHz  Feedback divider min=16, max=320  VCO frequency min=400MHz, max=1600MHz
$40028004 constant PLL_SYS_PWR \ Controls the PLL power modes.
$40028008 constant PLL_SYS_FBDIV_INT \ Feedback divisor  note: this PLL does not support fractional division
$4002800C constant PLL_SYS_PRIM \ Controls the PLL post dividers for the primary output  note: this PLL does not have a secondary output  the primary output is driven from VCO divided by postdiv1*postdiv2

\ =========================== PLL_USB =========================== \
$4002C000 constant PLL_USB_CS \ Control and Status  GENERAL CONSTRAINTS:  Reference clock frequency min=5MHz, max=800MHz  Feedback divider min=16, max=320  VCO frequency min=400MHz, max=1600MHz
$4002C004 constant PLL_USB_PWR \ Controls the PLL power modes.
$4002C008 constant PLL_USB_FBDIV_INT \ Feedback divisor  note: this PLL does not support fractional division
$4002C00C constant PLL_USB_PRIM \ Controls the PLL post dividers for the primary output  note: this PLL does not have a secondary output  the primary output is driven from VCO divided by postdiv1*postdiv2

\ =========================== BUSCTRL =========================== \
$40030000 constant BUSCTRL_BUS_PRIORITY \ Set the priority of each master for bus arbitration.
$40030004 constant BUSCTRL_BUS_PRIORITY_ACK \ Bus priority acknowledge
$40030008 constant BUSCTRL_PERFCTR0 \ Bus fabric performance counter 0
$4003000C constant BUSCTRL_PERFSEL0 \ Bus fabric performance event select for PERFCTR0
$40030010 constant BUSCTRL_PERFCTR1 \ Bus fabric performance counter 1
$40030014 constant BUSCTRL_PERFSEL1 \ Bus fabric performance event select for PERFCTR1
$40030018 constant BUSCTRL_PERFCTR2 \ Bus fabric performance counter 2
$4003001C constant BUSCTRL_PERFSEL2 \ Bus fabric performance event select for PERFCTR2
$40030020 constant BUSCTRL_PERFCTR3 \ Bus fabric performance counter 3
$40030024 constant BUSCTRL_PERFSEL3 \ Bus fabric performance event select for PERFCTR3

\ =========================== UART0 =========================== \
$40034000 constant UART0_UARTDR \ Data Register, UARTDR
$40034004 constant UART0_UARTRSR \ Receive Status Register/Error Clear Register, UARTRSR/UARTECR
$40034018 constant UART0_UARTFR \ Flag Register, UARTFR
$40034020 constant UART0_UARTILPR \ IrDA Low-Power Counter Register, UARTILPR
$40034024 constant UART0_UARTIBRD \ Integer Baud Rate Register, UARTIBRD
$40034028 constant UART0_UARTFBRD \ Fractional Baud Rate Register, UARTFBRD
$4003402C constant UART0_UARTLCR_H \ Line Control Register, UARTLCR_H
$40034030 constant UART0_UARTCR \ Control Register, UARTCR
$40034034 constant UART0_UARTIFLS \ Interrupt FIFO Level Select Register, UARTIFLS
$40034038 constant UART0_UARTIMSC \ Interrupt Mask Set/Clear Register, UARTIMSC
$4003403C constant UART0_UARTRIS \ Raw Interrupt Status Register, UARTRIS
$40034040 constant UART0_UARTMIS \ Masked Interrupt Status Register, UARTMIS
$40034044 constant UART0_UARTICR \ Interrupt Clear Register, UARTICR
$40034048 constant UART0_UARTDMACR \ DMA Control Register, UARTDMACR
$40034FE0 constant UART0_UARTPERIPHID0 \ UARTPeriphID0 Register
$40034FE4 constant UART0_UARTPERIPHID1 \ UARTPeriphID1 Register
$40034FE8 constant UART0_UARTPERIPHID2 \ UARTPeriphID2 Register
$40034FEC constant UART0_UARTPERIPHID3 \ UARTPeriphID3 Register
$40034FF0 constant UART0_UARTPCELLID0 \ UARTPCellID0 Register
$40034FF4 constant UART0_UARTPCELLID1 \ UARTPCellID1 Register
$40034FF8 constant UART0_UARTPCELLID2 \ UARTPCellID2 Register
$40034FFC constant UART0_UARTPCELLID3 \ UARTPCellID3 Register

\ =========================== UART1 =========================== \
$40038000 constant UART1_UARTDR \ Data Register, UARTDR
$40038004 constant UART1_UARTRSR \ Receive Status Register/Error Clear Register, UARTRSR/UARTECR
$40038018 constant UART1_UARTFR \ Flag Register, UARTFR
$40038020 constant UART1_UARTILPR \ IrDA Low-Power Counter Register, UARTILPR
$40038024 constant UART1_UARTIBRD \ Integer Baud Rate Register, UARTIBRD
$40038028 constant UART1_UARTFBRD \ Fractional Baud Rate Register, UARTFBRD
$4003802C constant UART1_UARTLCR_H \ Line Control Register, UARTLCR_H
$40038030 constant UART1_UARTCR \ Control Register, UARTCR
$40038034 constant UART1_UARTIFLS \ Interrupt FIFO Level Select Register, UARTIFLS
$40038038 constant UART1_UARTIMSC \ Interrupt Mask Set/Clear Register, UARTIMSC
$4003803C constant UART1_UARTRIS \ Raw Interrupt Status Register, UARTRIS
$40038040 constant UART1_UARTMIS \ Masked Interrupt Status Register, UARTMIS
$40038044 constant UART1_UARTICR \ Interrupt Clear Register, UARTICR
$40038048 constant UART1_UARTDMACR \ DMA Control Register, UARTDMACR
$40038FE0 constant UART1_UARTPERIPHID0 \ UARTPeriphID0 Register
$40038FE4 constant UART1_UARTPERIPHID1 \ UARTPeriphID1 Register
$40038FE8 constant UART1_UARTPERIPHID2 \ UARTPeriphID2 Register
$40038FEC constant UART1_UARTPERIPHID3 \ UARTPeriphID3 Register
$40038FF0 constant UART1_UARTPCELLID0 \ UARTPCellID0 Register
$40038FF4 constant UART1_UARTPCELLID1 \ UARTPCellID1 Register
$40038FF8 constant UART1_UARTPCELLID2 \ UARTPCellID2 Register
$40038FFC constant UART1_UARTPCELLID3 \ UARTPCellID3 Register

\ =========================== SPI0 =========================== \
$4003C000 constant SPI0_SSPCR0 \ Control register 0, SSPCR0 on page 3-4
$4003C004 constant SPI0_SSPCR1 \ Control register 1, SSPCR1 on page 3-5
$4003C008 constant SPI0_SSPDR \ Data register, SSPDR on page 3-6
$4003C00C constant SPI0_SSPSR \ Status register, SSPSR on page 3-7
$4003C010 constant SPI0_SSPCPSR \ Clock prescale register, SSPCPSR on page 3-8
$4003C014 constant SPI0_SSPIMSC \ Interrupt mask set or clear register, SSPIMSC on page 3-9
$4003C018 constant SPI0_SSPRIS \ Raw interrupt status register, SSPRIS on page 3-10
$4003C01C constant SPI0_SSPMIS \ Masked interrupt status register, SSPMIS on page 3-11
$4003C020 constant SPI0_SSPICR \ Interrupt clear register, SSPICR on page 3-11
$4003C024 constant SPI0_SSPDMACR \ DMA control register, SSPDMACR on page 3-12
$4003CFE0 constant SPI0_SSPPERIPHID0 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$4003CFE4 constant SPI0_SSPPERIPHID1 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$4003CFE8 constant SPI0_SSPPERIPHID2 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$4003CFEC constant SPI0_SSPPERIPHID3 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$4003CFF0 constant SPI0_SSPPCELLID0 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16
$4003CFF4 constant SPI0_SSPPCELLID1 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16
$4003CFF8 constant SPI0_SSPPCELLID2 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16
$4003CFFC constant SPI0_SSPPCELLID3 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16

\ =========================== SPI1 =========================== \
$40040000 constant SPI1_SSPCR0 \ Control register 0, SSPCR0 on page 3-4
$40040004 constant SPI1_SSPCR1 \ Control register 1, SSPCR1 on page 3-5
$40040008 constant SPI1_SSPDR \ Data register, SSPDR on page 3-6
$4004000C constant SPI1_SSPSR \ Status register, SSPSR on page 3-7
$40040010 constant SPI1_SSPCPSR \ Clock prescale register, SSPCPSR on page 3-8
$40040014 constant SPI1_SSPIMSC \ Interrupt mask set or clear register, SSPIMSC on page 3-9
$40040018 constant SPI1_SSPRIS \ Raw interrupt status register, SSPRIS on page 3-10
$4004001C constant SPI1_SSPMIS \ Masked interrupt status register, SSPMIS on page 3-11
$40040020 constant SPI1_SSPICR \ Interrupt clear register, SSPICR on page 3-11
$40040024 constant SPI1_SSPDMACR \ DMA control register, SSPDMACR on page 3-12
$40040FE0 constant SPI1_SSPPERIPHID0 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$40040FE4 constant SPI1_SSPPERIPHID1 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$40040FE8 constant SPI1_SSPPERIPHID2 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$40040FEC constant SPI1_SSPPERIPHID3 \ Peripheral identification registers, SSPPeriphID0-3 on page 3-13
$40040FF0 constant SPI1_SSPPCELLID0 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16
$40040FF4 constant SPI1_SSPPCELLID1 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16
$40040FF8 constant SPI1_SSPPCELLID2 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16
$40040FFC constant SPI1_SSPPCELLID3 \ PrimeCell identification registers, SSPPCellID0-3 on page 3-16

\ =========================== I2C0 =========================== \
$40044000 constant I2C0_IC_CON \ I2C Control Register. This register can be written only when the DW_apb_i2c is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  Read/Write Access: - bit 10 is read only. - bit 11 is read only - bit 16 is read only - bit 17 is read only - bits 18 and 19 are read only.
$40044004 constant I2C0_IC_TAR \ I2C Target Address Register  This register is 12 bits wide, and bits 31:12 are reserved. This register can be written to only when IC_ENABLE[0] is set to 0.  Note: If the software or application is aware that the DW_apb_i2c is not using the TAR address for the pending commands in the Tx FIFO, then it is possible to update the TAR address even while the Tx FIFO has entries IC_STATUS[2]= 0. - It is not necessary to perform any write to this register if DW_apb_i2c is enabled as an I2C slave only.
$40044008 constant I2C0_IC_SAR \ I2C Slave Address Register
$40044010 constant I2C0_IC_DATA_CMD \ I2C Rx/Tx Data Buffer and Command Register; this is the register the CPU writes to when filling the TX FIFO and the CPU reads from when retrieving bytes from RX FIFO.  The size of the register changes as follows:  Write: - 11 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=1 - 9 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=0 Read: - 12 bits when IC_FIRST_DATA_BYTE_STATUS = 1 - 8 bits when IC_FIRST_DATA_BYTE_STATUS = 0 Note: In order for the DW_apb_i2c to continue acknowledging reads, a read command should be written for every byte that is to be received; otherwise the DW_apb_i2c will stop acknowledging.
$40044014 constant I2C0_IC_SS_SCL_HCNT \ Standard Speed I2C Clock SCL High Count Register
$40044018 constant I2C0_IC_SS_SCL_LCNT \ Standard Speed I2C Clock SCL Low Count Register
$4004401C constant I2C0_IC_FS_SCL_HCNT \ Fast Mode or Fast Mode Plus I2C Clock SCL High Count Register
$40044020 constant I2C0_IC_FS_SCL_LCNT \ Fast Mode or Fast Mode Plus I2C Clock SCL Low Count Register
$4004402C constant I2C0_IC_INTR_STAT \ I2C Interrupt Status Register  Each bit in this register has a corresponding mask bit in the IC_INTR_MASK register. These bits are cleared by reading the matching interrupt clear register. The unmasked raw versions of these bits are available in the IC_RAW_INTR_STAT register.
$40044030 constant I2C0_IC_INTR_MASK \ I2C Interrupt Mask Register.  These bits mask their corresponding interrupt status bits. This register is active low; a value of 0 masks the interrupt, whereas a value of 1 unmasks the interrupt.
$40044034 constant I2C0_IC_RAW_INTR_STAT \ I2C Raw Interrupt Status Register  Unlike the IC_INTR_STAT register, these bits are not masked so they always show the true status of the DW_apb_i2c.
$40044038 constant I2C0_IC_RX_TL \ I2C Receive FIFO Threshold Register
$4004403C constant I2C0_IC_TX_TL \ I2C Transmit FIFO Threshold Register
$40044040 constant I2C0_IC_CLR_INTR \ Clear Combined and Individual Interrupt Register
$40044044 constant I2C0_IC_CLR_RX_UNDER \ Clear RX_UNDER Interrupt Register
$40044048 constant I2C0_IC_CLR_RX_OVER \ Clear RX_OVER Interrupt Register
$4004404C constant I2C0_IC_CLR_TX_OVER \ Clear TX_OVER Interrupt Register
$40044050 constant I2C0_IC_CLR_RD_REQ \ Clear RD_REQ Interrupt Register
$40044054 constant I2C0_IC_CLR_TX_ABRT \ Clear TX_ABRT Interrupt Register
$40044058 constant I2C0_IC_CLR_RX_DONE \ Clear RX_DONE Interrupt Register
$4004405C constant I2C0_IC_CLR_ACTIVITY \ Clear ACTIVITY Interrupt Register
$40044060 constant I2C0_IC_CLR_STOP_DET \ Clear STOP_DET Interrupt Register
$40044064 constant I2C0_IC_CLR_START_DET \ Clear START_DET Interrupt Register
$40044068 constant I2C0_IC_CLR_GEN_CALL \ Clear GEN_CALL Interrupt Register
$4004406C constant I2C0_IC_ENABLE \ I2C Enable Register
$40044070 constant I2C0_IC_STATUS \ I2C Status Register  This is a read-only register used to indicate the current transfer status and FIFO status. The status register may be read at any time. None of the bits in this register request an interrupt.  When the I2C is disabled by writing 0 in bit 0 of the IC_ENABLE register: - Bits 1 and 2 are set to 1 - Bits 3 and 10 are set to 0 When the master or slave state machines goes to idle and ic_en=0: - Bits 5 and 6 are set to 0
$40044074 constant I2C0_IC_TXFLR \ I2C Transmit FIFO Level Register This register contains the number of valid data entries in the transmit FIFO buffer. It is cleared whenever: - The I2C is disabled - There is a transmit abort - that is, TX_ABRT bit is set in the IC_RAW_INTR_STAT register - The slave bulk transmit mode is aborted The register increments whenever data is placed into the transmit FIFO and decrements when data is taken from the transmit FIFO.
$40044078 constant I2C0_IC_RXFLR \ I2C Receive FIFO Level Register This register contains the number of valid data entries in the receive FIFO buffer. It is cleared whenever: - The I2C is disabled - Whenever there is a transmit abort caused by any of the events tracked in IC_TX_ABRT_SOURCE The register increments whenever data is placed into the receive FIFO and decrements when data is taken from the receive FIFO.
$4004407C constant I2C0_IC_SDA_HOLD \ I2C SDA Hold Time Length Register  The bits [15:0] of this register are used to control the hold time of SDA during transmit in both slave and master mode after SCL goes from HIGH to LOW.  The bits [23:16] of this register are used to extend the SDA transition if any whenever SCL is HIGH in the receiver in either master or slave mode.  Writes to this register succeed only when IC_ENABLE[0]=0.  The values in this register are in units of ic_clk period. The value programmed in IC_SDA_TX_HOLD must be greater than the minimum hold time in each mode one cycle in master mode, seven cycles in slave mode for the value to be implemented.  The programmed SDA hold time during transmit IC_SDA_TX_HOLD cannot exceed at any time the duration of the low part of scl. Therefore the programmed value cannot be larger than N_SCL_LOW-2, where N_SCL_LOW is the duration of the low part of the scl period measured in ic_clk cycles.
$40044080 constant I2C0_IC_TX_ABRT_SOURCE \ I2C Transmit Abort Source Register  This register has 32 bits that indicate the source of the TX_ABRT bit. Except for Bit 9, this register is cleared whenever the IC_CLR_TX_ABRT register or the IC_CLR_INTR register is read. To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; RESTART must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10].  Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, Bit 9 clears for one cycle and is then re-asserted.
$40044084 constant I2C0_IC_SLV_DATA_NACK_ONLY \ Generate Slave Data NACK Register  The register is used to generate a NACK for the data part of a transfer when DW_apb_i2c is acting as a slave-receiver. This register only exists when the IC_SLV_DATA_NACK_ONLY parameter is set to 1. When this parameter disabled, this register does not exist and writing to the register's address has no effect.  A write can occur on this register if both of the following conditions are met: - DW_apb_i2c is disabled IC_ENABLE[0] = 0 - Slave part is inactive IC_STATUS[6] = 0 Note: The IC_STATUS[6] is a register read-back location for the internal slv_activity signal; the user should poll this before writing the ic_slv_data_nack_only bit.
$40044088 constant I2C0_IC_DMA_CR \ DMA Control Register  The register is used to enable the DMA Controller interface operation. There is a separate bit for transmit and receive. This can be programmed regardless of the state of IC_ENABLE.
$4004408C constant I2C0_IC_DMA_TDLR \ DMA Transmit Data Level Register
$40044090 constant I2C0_IC_DMA_RDLR \ I2C Receive Data Level Register
$40044094 constant I2C0_IC_SDA_SETUP \ I2C SDA Setup Register  This register controls the amount of time delay in terms of number of ic_clk clock periods introduced in the rising edge of SCL - relative to SDA changing - when DW_apb_i2c services a read request in a slave-transmitter operation. The relevant I2C requirement is tSU:DAT note 4 as detailed in the I2C Bus Specification. This register must be programmed with a value equal to or greater than 2.  Writes to this register succeed only when IC_ENABLE[0] = 0.  Note: The length of setup time is calculated using [IC_SDA_SETUP - 1 * ic_clk_period], so if the user requires 10 ic_clk periods of setup time, they should program a value of 11. The IC_SDA_SETUP register is only used by the DW_apb_i2c when operating as a slave transmitter.
$40044098 constant I2C0_IC_ACK_GENERAL_CALL \ I2C ACK General Call Register  The register controls whether DW_apb_i2c responds with a ACK or NACK when it receives an I2C General Call address.  This register is applicable only when the DW_apb_i2c is in slave mode.
$4004409C constant I2C0_IC_ENABLE_STATUS \ I2C Enable Status Register  The register is used to report the DW_apb_i2c hardware status when the IC_ENABLE[0] register is set from 1 to 0; that is, when DW_apb_i2c is disabled.  If IC_ENABLE[0] has been set to 1, bits 2:1 are forced to 0, and bit 0 is forced to 1.  If IC_ENABLE[0] has been set to 0, bits 2:1 is only be valid as soon as bit 0 is read as '0'.  Note: When IC_ENABLE[0] has been set to 0, a delay occurs for bit 0 to be read as 0 because disabling the DW_apb_i2c depends on I2C bus activities.
$400440A0 constant I2C0_IC_FS_SPKLEN \ I2C SS, FS or FM+ spike suppression limit  This register is used to store the duration, measured in ic_clk cycles, of the longest spike that is filtered out by the spike suppression logic when the component is operating in SS, FS or FM+ modes. The relevant I2C requirement is tSP table 4 as detailed in the I2C Bus Specification. This register must be programmed with a minimum value of 1.
$400440A8 constant I2C0_IC_CLR_RESTART_DET \ Clear RESTART_DET Interrupt Register
$400440F4 constant I2C0_IC_COMP_PARAM_1 \ Component Parameter Register 1  Note This register is not implemented and therefore reads as 0. If it was implemented it would be a constant read-only register that contains encoded information about the component's parameter settings. Fields shown below are the settings for those parameters
$400440F8 constant I2C0_IC_COMP_VERSION \ I2C Component Version Register
$400440FC constant I2C0_IC_COMP_TYPE \ I2C Component Type Register

\ =========================== I2C1 =========================== \
$40048000 constant I2C1_IC_CON \ I2C Control Register. This register can be written only when the DW_apb_i2c is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  Read/Write Access: - bit 10 is read only. - bit 11 is read only - bit 16 is read only - bit 17 is read only - bits 18 and 19 are read only.
$40048004 constant I2C1_IC_TAR \ I2C Target Address Register  This register is 12 bits wide, and bits 31:12 are reserved. This register can be written to only when IC_ENABLE[0] is set to 0.  Note: If the software or application is aware that the DW_apb_i2c is not using the TAR address for the pending commands in the Tx FIFO, then it is possible to update the TAR address even while the Tx FIFO has entries IC_STATUS[2]= 0. - It is not necessary to perform any write to this register if DW_apb_i2c is enabled as an I2C slave only.
$40048008 constant I2C1_IC_SAR \ I2C Slave Address Register
$40048010 constant I2C1_IC_DATA_CMD \ I2C Rx/Tx Data Buffer and Command Register; this is the register the CPU writes to when filling the TX FIFO and the CPU reads from when retrieving bytes from RX FIFO.  The size of the register changes as follows:  Write: - 11 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=1 - 9 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=0 Read: - 12 bits when IC_FIRST_DATA_BYTE_STATUS = 1 - 8 bits when IC_FIRST_DATA_BYTE_STATUS = 0 Note: In order for the DW_apb_i2c to continue acknowledging reads, a read command should be written for every byte that is to be received; otherwise the DW_apb_i2c will stop acknowledging.
$40048014 constant I2C1_IC_SS_SCL_HCNT \ Standard Speed I2C Clock SCL High Count Register
$40048018 constant I2C1_IC_SS_SCL_LCNT \ Standard Speed I2C Clock SCL Low Count Register
$4004801C constant I2C1_IC_FS_SCL_HCNT \ Fast Mode or Fast Mode Plus I2C Clock SCL High Count Register
$40048020 constant I2C1_IC_FS_SCL_LCNT \ Fast Mode or Fast Mode Plus I2C Clock SCL Low Count Register
$4004802C constant I2C1_IC_INTR_STAT \ I2C Interrupt Status Register  Each bit in this register has a corresponding mask bit in the IC_INTR_MASK register. These bits are cleared by reading the matching interrupt clear register. The unmasked raw versions of these bits are available in the IC_RAW_INTR_STAT register.
$40048030 constant I2C1_IC_INTR_MASK \ I2C Interrupt Mask Register.  These bits mask their corresponding interrupt status bits. This register is active low; a value of 0 masks the interrupt, whereas a value of 1 unmasks the interrupt.
$40048034 constant I2C1_IC_RAW_INTR_STAT \ I2C Raw Interrupt Status Register  Unlike the IC_INTR_STAT register, these bits are not masked so they always show the true status of the DW_apb_i2c.
$40048038 constant I2C1_IC_RX_TL \ I2C Receive FIFO Threshold Register
$4004803C constant I2C1_IC_TX_TL \ I2C Transmit FIFO Threshold Register
$40048040 constant I2C1_IC_CLR_INTR \ Clear Combined and Individual Interrupt Register
$40048044 constant I2C1_IC_CLR_RX_UNDER \ Clear RX_UNDER Interrupt Register
$40048048 constant I2C1_IC_CLR_RX_OVER \ Clear RX_OVER Interrupt Register
$4004804C constant I2C1_IC_CLR_TX_OVER \ Clear TX_OVER Interrupt Register
$40048050 constant I2C1_IC_CLR_RD_REQ \ Clear RD_REQ Interrupt Register
$40048054 constant I2C1_IC_CLR_TX_ABRT \ Clear TX_ABRT Interrupt Register
$40048058 constant I2C1_IC_CLR_RX_DONE \ Clear RX_DONE Interrupt Register
$4004805C constant I2C1_IC_CLR_ACTIVITY \ Clear ACTIVITY Interrupt Register
$40048060 constant I2C1_IC_CLR_STOP_DET \ Clear STOP_DET Interrupt Register
$40048064 constant I2C1_IC_CLR_START_DET \ Clear START_DET Interrupt Register
$40048068 constant I2C1_IC_CLR_GEN_CALL \ Clear GEN_CALL Interrupt Register
$4004806C constant I2C1_IC_ENABLE \ I2C Enable Register
$40048070 constant I2C1_IC_STATUS \ I2C Status Register  This is a read-only register used to indicate the current transfer status and FIFO status. The status register may be read at any time. None of the bits in this register request an interrupt.  When the I2C is disabled by writing 0 in bit 0 of the IC_ENABLE register: - Bits 1 and 2 are set to 1 - Bits 3 and 10 are set to 0 When the master or slave state machines goes to idle and ic_en=0: - Bits 5 and 6 are set to 0
$40048074 constant I2C1_IC_TXFLR \ I2C Transmit FIFO Level Register This register contains the number of valid data entries in the transmit FIFO buffer. It is cleared whenever: - The I2C is disabled - There is a transmit abort - that is, TX_ABRT bit is set in the IC_RAW_INTR_STAT register - The slave bulk transmit mode is aborted The register increments whenever data is placed into the transmit FIFO and decrements when data is taken from the transmit FIFO.
$40048078 constant I2C1_IC_RXFLR \ I2C Receive FIFO Level Register This register contains the number of valid data entries in the receive FIFO buffer. It is cleared whenever: - The I2C is disabled - Whenever there is a transmit abort caused by any of the events tracked in IC_TX_ABRT_SOURCE The register increments whenever data is placed into the receive FIFO and decrements when data is taken from the receive FIFO.
$4004807C constant I2C1_IC_SDA_HOLD \ I2C SDA Hold Time Length Register  The bits [15:0] of this register are used to control the hold time of SDA during transmit in both slave and master mode after SCL goes from HIGH to LOW.  The bits [23:16] of this register are used to extend the SDA transition if any whenever SCL is HIGH in the receiver in either master or slave mode.  Writes to this register succeed only when IC_ENABLE[0]=0.  The values in this register are in units of ic_clk period. The value programmed in IC_SDA_TX_HOLD must be greater than the minimum hold time in each mode one cycle in master mode, seven cycles in slave mode for the value to be implemented.  The programmed SDA hold time during transmit IC_SDA_TX_HOLD cannot exceed at any time the duration of the low part of scl. Therefore the programmed value cannot be larger than N_SCL_LOW-2, where N_SCL_LOW is the duration of the low part of the scl period measured in ic_clk cycles.
$40048080 constant I2C1_IC_TX_ABRT_SOURCE \ I2C Transmit Abort Source Register  This register has 32 bits that indicate the source of the TX_ABRT bit. Except for Bit 9, this register is cleared whenever the IC_CLR_TX_ABRT register or the IC_CLR_INTR register is read. To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; RESTART must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10].  Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, Bit 9 clears for one cycle and is then re-asserted.
$40048084 constant I2C1_IC_SLV_DATA_NACK_ONLY \ Generate Slave Data NACK Register  The register is used to generate a NACK for the data part of a transfer when DW_apb_i2c is acting as a slave-receiver. This register only exists when the IC_SLV_DATA_NACK_ONLY parameter is set to 1. When this parameter disabled, this register does not exist and writing to the register's address has no effect.  A write can occur on this register if both of the following conditions are met: - DW_apb_i2c is disabled IC_ENABLE[0] = 0 - Slave part is inactive IC_STATUS[6] = 0 Note: The IC_STATUS[6] is a register read-back location for the internal slv_activity signal; the user should poll this before writing the ic_slv_data_nack_only bit.
$40048088 constant I2C1_IC_DMA_CR \ DMA Control Register  The register is used to enable the DMA Controller interface operation. There is a separate bit for transmit and receive. This can be programmed regardless of the state of IC_ENABLE.
$4004808C constant I2C1_IC_DMA_TDLR \ DMA Transmit Data Level Register
$40048090 constant I2C1_IC_DMA_RDLR \ I2C Receive Data Level Register
$40048094 constant I2C1_IC_SDA_SETUP \ I2C SDA Setup Register  This register controls the amount of time delay in terms of number of ic_clk clock periods introduced in the rising edge of SCL - relative to SDA changing - when DW_apb_i2c services a read request in a slave-transmitter operation. The relevant I2C requirement is tSU:DAT note 4 as detailed in the I2C Bus Specification. This register must be programmed with a value equal to or greater than 2.  Writes to this register succeed only when IC_ENABLE[0] = 0.  Note: The length of setup time is calculated using [IC_SDA_SETUP - 1 * ic_clk_period], so if the user requires 10 ic_clk periods of setup time, they should program a value of 11. The IC_SDA_SETUP register is only used by the DW_apb_i2c when operating as a slave transmitter.
$40048098 constant I2C1_IC_ACK_GENERAL_CALL \ I2C ACK General Call Register  The register controls whether DW_apb_i2c responds with a ACK or NACK when it receives an I2C General Call address.  This register is applicable only when the DW_apb_i2c is in slave mode.
$4004809C constant I2C1_IC_ENABLE_STATUS \ I2C Enable Status Register  The register is used to report the DW_apb_i2c hardware status when the IC_ENABLE[0] register is set from 1 to 0; that is, when DW_apb_i2c is disabled.  If IC_ENABLE[0] has been set to 1, bits 2:1 are forced to 0, and bit 0 is forced to 1.  If IC_ENABLE[0] has been set to 0, bits 2:1 is only be valid as soon as bit 0 is read as '0'.  Note: When IC_ENABLE[0] has been set to 0, a delay occurs for bit 0 to be read as 0 because disabling the DW_apb_i2c depends on I2C bus activities.
$400480A0 constant I2C1_IC_FS_SPKLEN \ I2C SS, FS or FM+ spike suppression limit  This register is used to store the duration, measured in ic_clk cycles, of the longest spike that is filtered out by the spike suppression logic when the component is operating in SS, FS or FM+ modes. The relevant I2C requirement is tSP table 4 as detailed in the I2C Bus Specification. This register must be programmed with a minimum value of 1.
$400480A8 constant I2C1_IC_CLR_RESTART_DET \ Clear RESTART_DET Interrupt Register
$400480F4 constant I2C1_IC_COMP_PARAM_1 \ Component Parameter Register 1  Note This register is not implemented and therefore reads as 0. If it was implemented it would be a constant read-only register that contains encoded information about the component's parameter settings. Fields shown below are the settings for those parameters
$400480F8 constant I2C1_IC_COMP_VERSION \ I2C Component Version Register
$400480FC constant I2C1_IC_COMP_TYPE \ I2C Component Type Register

\ =========================== ADC =========================== \
$4004C000 constant ADC_CS \ ADC Control and Status
$4004C004 constant ADC_RESULT \ Result of most recent ADC conversion
$4004C008 constant ADC_FCS \ FIFO control and status
$4004C00C constant ADC_FIFO \ Conversion result FIFO
$4004C010 constant ADC_DIV \ Clock divider. If non-zero, CS_START_MANY will start conversions  at regular intervals rather than back-to-back.  The divider is reset when either of these fields are written.  Total period is 1 + INT + FRAC / 256
$4004C014 constant ADC_INTR \ Raw Interrupts
$4004C018 constant ADC_INTE \ Interrupt Enable
$4004C01C constant ADC_INTF \ Interrupt Force
$4004C020 constant ADC_INTS \ Interrupt status after masking & forcing

\ =========================== PWM =========================== \
$40050000 constant PWM_CH0_CSR \ Control and status register
$40050004 constant PWM_CH0_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$40050008 constant PWM_CH0_CTR \ Direct access to the PWM counter
$4005000C constant PWM_CH0_CC \ Counter compare values
$40050010 constant PWM_CH0_TOP \ Counter wrap value
$40050014 constant PWM_CH1_CSR \ Control and status register
$40050018 constant PWM_CH1_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$4005001C constant PWM_CH1_CTR \ Direct access to the PWM counter
$40050020 constant PWM_CH1_CC \ Counter compare values
$40050024 constant PWM_CH1_TOP \ Counter wrap value
$40050028 constant PWM_CH2_CSR \ Control and status register
$4005002C constant PWM_CH2_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$40050030 constant PWM_CH2_CTR \ Direct access to the PWM counter
$40050034 constant PWM_CH2_CC \ Counter compare values
$40050038 constant PWM_CH2_TOP \ Counter wrap value
$4005003C constant PWM_CH3_CSR \ Control and status register
$40050040 constant PWM_CH3_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$40050044 constant PWM_CH3_CTR \ Direct access to the PWM counter
$40050048 constant PWM_CH3_CC \ Counter compare values
$4005004C constant PWM_CH3_TOP \ Counter wrap value
$40050050 constant PWM_CH4_CSR \ Control and status register
$40050054 constant PWM_CH4_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$40050058 constant PWM_CH4_CTR \ Direct access to the PWM counter
$4005005C constant PWM_CH4_CC \ Counter compare values
$40050060 constant PWM_CH4_TOP \ Counter wrap value
$40050064 constant PWM_CH5_CSR \ Control and status register
$40050068 constant PWM_CH5_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$4005006C constant PWM_CH5_CTR \ Direct access to the PWM counter
$40050070 constant PWM_CH5_CC \ Counter compare values
$40050074 constant PWM_CH5_TOP \ Counter wrap value
$40050078 constant PWM_CH6_CSR \ Control and status register
$4005007C constant PWM_CH6_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$40050080 constant PWM_CH6_CTR \ Direct access to the PWM counter
$40050084 constant PWM_CH6_CC \ Counter compare values
$40050088 constant PWM_CH6_TOP \ Counter wrap value
$4005008C constant PWM_CH7_CSR \ Control and status register
$40050090 constant PWM_CH7_DIV \ INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
$40050094 constant PWM_CH7_CTR \ Direct access to the PWM counter
$40050098 constant PWM_CH7_CC \ Counter compare values
$4005009C constant PWM_CH7_TOP \ Counter wrap value
$400500A0 constant PWM_EN \ This register aliases the CSR_EN bits for all channels.  Writing to this register allows multiple channels to be enabled  or disabled simultaneously, so they can run in perfect sync.  For each channel, there is only one physical EN register bit,  which can be accessed through here or CHx_CSR.
$400500A4 constant PWM_INTR \ Raw Interrupts
$400500A8 constant PWM_INTE \ Interrupt Enable
$400500AC constant PWM_INTF \ Interrupt Force
$400500B0 constant PWM_INTS \ Interrupt status after masking & forcing

\ =========================== TIMER =========================== \
$40054000 constant TIMER_TIMEHW \ Write to bits 63:32 of time  always write timelw before timehw
$40054004 constant TIMER_TIMELW \ Write to bits 31:0 of time  writes do not get copied to time until timehw is written
$40054008 constant TIMER_TIMEHR \ Read from bits 63:32 of time  always read timelr before timehr
$4005400C constant TIMER_TIMELR \ Read from bits 31:0 of time
$40054010 constant TIMER_ALARM0 \ Arm alarm 0, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM0 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
$40054014 constant TIMER_ALARM1 \ Arm alarm 1, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM1 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
$40054018 constant TIMER_ALARM2 \ Arm alarm 2, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM2 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
$4005401C constant TIMER_ALARM3 \ Arm alarm 3, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM3 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
$40054020 constant TIMER_ARMED \ Indicates the armed/disarmed status of each alarm.  A write to the corresponding ALARMx register arms the alarm.  Alarms automatically disarm upon firing, but writing ones here  will disarm immediately without waiting to fire.
$40054024 constant TIMER_TIMERAWH \ Raw read from bits 63:32 of time no side effects
$40054028 constant TIMER_TIMERAWL \ Raw read from bits 31:0 of time no side effects
$4005402C constant TIMER_DBGPAUSE \ Set bits high to enable pause when the corresponding debug ports are active
$40054030 constant TIMER_PAUSE \ Set high to pause the timer
$40054034 constant TIMER_INTR \ Raw Interrupts
$40054038 constant TIMER_INTE \ Interrupt Enable
$4005403C constant TIMER_INTF \ Interrupt Force
$40054040 constant TIMER_INTS \ Interrupt status after masking & forcing

\ =========================== WATCHDOG =========================== \
$40058000 constant WATCHDOG_CTRL \ Watchdog control  The rst_wdsel register determines which subsystems are reset when the watchdog is triggered.  The watchdog can be triggered in software.
$40058004 constant WATCHDOG_LOAD \ Load the watchdog timer. The maximum setting is $ffffff which corresponds to $ffffff / 2 ticks before triggering a watchdog reset see errata RP2040-E1.
$40058008 constant WATCHDOG_REASON \ Logs the reason for the last reset. Both bits are zero for the case of a hardware reset.
$4005800C constant WATCHDOG_SCRATCH0 \ Scratch register. Information persists through soft reset of the chip.
$40058010 constant WATCHDOG_SCRATCH1 \ Scratch register. Information persists through soft reset of the chip.
$40058014 constant WATCHDOG_SCRATCH2 \ Scratch register. Information persists through soft reset of the chip.
$40058018 constant WATCHDOG_SCRATCH3 \ Scratch register. Information persists through soft reset of the chip.
$4005801C constant WATCHDOG_SCRATCH4 \ Scratch register. Information persists through soft reset of the chip.
$40058020 constant WATCHDOG_SCRATCH5 \ Scratch register. Information persists through soft reset of the chip.
$40058024 constant WATCHDOG_SCRATCH6 \ Scratch register. Information persists through soft reset of the chip.
$40058028 constant WATCHDOG_SCRATCH7 \ Scratch register. Information persists through soft reset of the chip.
$4005802C constant WATCHDOG_TICK \ Controls the tick generator

\ =========================== RTC =========================== \
$4005C000 constant RTC_CLKDIV_M1 \ Divider minus 1 for the 1 second counter. Safe to change the value when RTC is not enabled.
$4005C004 constant RTC_SETUP_0 \ RTC setup register 0
$4005C008 constant RTC_SETUP_1 \ RTC setup register 1
$4005C00C constant RTC_CTRL \ RTC Control and status
$4005C010 constant RTC_IRQ_SETUP_0 \ Interrupt setup register 0
$4005C014 constant RTC_IRQ_SETUP_1 \ Interrupt setup register 1
$4005C018 constant RTC_RTC_1 \ RTC register 1.
$4005C01C constant RTC_RTC_0 \ RTC register 0  Read this before RTC 1!
$4005C020 constant RTC_INTR \ Raw Interrupts
$4005C024 constant RTC_INTE \ Interrupt Enable
$4005C028 constant RTC_INTF \ Interrupt Force
$4005C02C constant RTC_INTS \ Interrupt status after masking & forcing

\ =========================== ROSC =========================== \
$40060000 constant ROSC_CTRL \ Ring Oscillator control
$40060004 constant ROSC_FREQA \ The FREQA & FREQB registers control the frequency by controlling the drive strength of each stage  The drive strength has 4 levels determined by the number of bits set  Increasing the number of bits set increases the drive strength and increases the oscillation frequency  0 bits set is the default drive strength  1 bit set doubles the drive strength  2 bits set triples drive strength  3 bits set quadruples drive strength
$40060008 constant ROSC_FREQB \ For a detailed description see freqa register
$4006000C constant ROSC_DORMANT \ Ring Oscillator pause control  This is used to save power by pausing the ROSC  On power-up this field is initialised to WAKE  An invalid write will also select WAKE  Warning: setup the irq before selecting dormant mode
$40060010 constant ROSC_DIV \ Controls the output divider
$40060014 constant ROSC_PHASE \ Controls the phase shifted output
$40060018 constant ROSC_STATUS \ Ring Oscillator Status
$4006001C constant ROSC_RANDOMBIT \ This just reads the state of the oscillator output so randomness is compromised if the ring oscillator is stopped or run at a harmonic of the bus frequency
$40060020 constant ROSC_COUNT \ A down counter running at the ROSC frequency which counts to zero and stops.  To start the counter write a non-zero value.  Can be used for short software pauses when setting up time sensitive hardware.

\ =========================== VREG_AND_CHIP_RESET =========================== \
$40064000 constant VREG_AND_CHIP_RESET_VREG \ Voltage regulator control and status
$40064004 constant VREG_AND_CHIP_RESET_BOD \ brown-out detection control
$40064008 constant VREG_AND_CHIP_RESET_CHIP_RESET \ Chip reset control and status

\ =========================== TBMAN =========================== \
$4006C000 constant TBMAN_PLATFORM \ Indicates the type of platform in use

\ =========================== DMA =========================== \
$50000000 constant DMA_CH0_READ_ADDR \ DMA Channel 0 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000004 constant DMA_CH0_WRITE_ADDR \ DMA Channel 0 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000008 constant DMA_CH0_TRANS_COUNT \ DMA Channel 0 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000000C constant DMA_CH0_CTRL_TRIG \ DMA Channel 0 Control and Status
$50000010 constant DMA_CH0_AL1_CTRL \ Alias for channel 0 CTRL register
$50000014 constant DMA_CH0_AL1_READ_ADDR \ Alias for channel 0 READ_ADDR register
$50000018 constant DMA_CH0_AL1_WRITE_ADDR \ Alias for channel 0 WRITE_ADDR register
$5000001C constant DMA_CH0_AL1_TRANS_COUNT_TRIG \ Alias for channel 0 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000020 constant DMA_CH0_AL2_CTRL \ Alias for channel 0 CTRL register
$50000024 constant DMA_CH0_AL2_TRANS_COUNT \ Alias for channel 0 TRANS_COUNT register
$50000028 constant DMA_CH0_AL2_READ_ADDR \ Alias for channel 0 READ_ADDR register
$5000002C constant DMA_CH0_AL2_WRITE_ADDR_TRIG \ Alias for channel 0 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000030 constant DMA_CH0_AL3_CTRL \ Alias for channel 0 CTRL register
$50000034 constant DMA_CH0_AL3_WRITE_ADDR \ Alias for channel 0 WRITE_ADDR register
$50000038 constant DMA_CH0_AL3_TRANS_COUNT \ Alias for channel 0 TRANS_COUNT register
$5000003C constant DMA_CH0_AL3_READ_ADDR_TRIG \ Alias for channel 0 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000040 constant DMA_CH1_READ_ADDR \ DMA Channel 1 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000044 constant DMA_CH1_WRITE_ADDR \ DMA Channel 1 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000048 constant DMA_CH1_TRANS_COUNT \ DMA Channel 1 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000004C constant DMA_CH1_CTRL_TRIG \ DMA Channel 1 Control and Status
$50000050 constant DMA_CH1_AL1_CTRL \ Alias for channel 1 CTRL register
$50000054 constant DMA_CH1_AL1_READ_ADDR \ Alias for channel 1 READ_ADDR register
$50000058 constant DMA_CH1_AL1_WRITE_ADDR \ Alias for channel 1 WRITE_ADDR register
$5000005C constant DMA_CH1_AL1_TRANS_COUNT_TRIG \ Alias for channel 1 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000060 constant DMA_CH1_AL2_CTRL \ Alias for channel 1 CTRL register
$50000064 constant DMA_CH1_AL2_TRANS_COUNT \ Alias for channel 1 TRANS_COUNT register
$50000068 constant DMA_CH1_AL2_READ_ADDR \ Alias for channel 1 READ_ADDR register
$5000006C constant DMA_CH1_AL2_WRITE_ADDR_TRIG \ Alias for channel 1 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000070 constant DMA_CH1_AL3_CTRL \ Alias for channel 1 CTRL register
$50000074 constant DMA_CH1_AL3_WRITE_ADDR \ Alias for channel 1 WRITE_ADDR register
$50000078 constant DMA_CH1_AL3_TRANS_COUNT \ Alias for channel 1 TRANS_COUNT register
$5000007C constant DMA_CH1_AL3_READ_ADDR_TRIG \ Alias for channel 1 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000080 constant DMA_CH2_READ_ADDR \ DMA Channel 2 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000084 constant DMA_CH2_WRITE_ADDR \ DMA Channel 2 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000088 constant DMA_CH2_TRANS_COUNT \ DMA Channel 2 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000008C constant DMA_CH2_CTRL_TRIG \ DMA Channel 2 Control and Status
$50000090 constant DMA_CH2_AL1_CTRL \ Alias for channel 2 CTRL register
$50000094 constant DMA_CH2_AL1_READ_ADDR \ Alias for channel 2 READ_ADDR register
$50000098 constant DMA_CH2_AL1_WRITE_ADDR \ Alias for channel 2 WRITE_ADDR register
$5000009C constant DMA_CH2_AL1_TRANS_COUNT_TRIG \ Alias for channel 2 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500000A0 constant DMA_CH2_AL2_CTRL \ Alias for channel 2 CTRL register
$500000A4 constant DMA_CH2_AL2_TRANS_COUNT \ Alias for channel 2 TRANS_COUNT register
$500000A8 constant DMA_CH2_AL2_READ_ADDR \ Alias for channel 2 READ_ADDR register
$500000AC constant DMA_CH2_AL2_WRITE_ADDR_TRIG \ Alias for channel 2 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500000B0 constant DMA_CH2_AL3_CTRL \ Alias for channel 2 CTRL register
$500000B4 constant DMA_CH2_AL3_WRITE_ADDR \ Alias for channel 2 WRITE_ADDR register
$500000B8 constant DMA_CH2_AL3_TRANS_COUNT \ Alias for channel 2 TRANS_COUNT register
$500000BC constant DMA_CH2_AL3_READ_ADDR_TRIG \ Alias for channel 2 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500000C0 constant DMA_CH3_READ_ADDR \ DMA Channel 3 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$500000C4 constant DMA_CH3_WRITE_ADDR \ DMA Channel 3 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$500000C8 constant DMA_CH3_TRANS_COUNT \ DMA Channel 3 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$500000CC constant DMA_CH3_CTRL_TRIG \ DMA Channel 3 Control and Status
$500000D0 constant DMA_CH3_AL1_CTRL \ Alias for channel 3 CTRL register
$500000D4 constant DMA_CH3_AL1_READ_ADDR \ Alias for channel 3 READ_ADDR register
$500000D8 constant DMA_CH3_AL1_WRITE_ADDR \ Alias for channel 3 WRITE_ADDR register
$500000DC constant DMA_CH3_AL1_TRANS_COUNT_TRIG \ Alias for channel 3 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500000E0 constant DMA_CH3_AL2_CTRL \ Alias for channel 3 CTRL register
$500000E4 constant DMA_CH3_AL2_TRANS_COUNT \ Alias for channel 3 TRANS_COUNT register
$500000E8 constant DMA_CH3_AL2_READ_ADDR \ Alias for channel 3 READ_ADDR register
$500000EC constant DMA_CH3_AL2_WRITE_ADDR_TRIG \ Alias for channel 3 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500000F0 constant DMA_CH3_AL3_CTRL \ Alias for channel 3 CTRL register
$500000F4 constant DMA_CH3_AL3_WRITE_ADDR \ Alias for channel 3 WRITE_ADDR register
$500000F8 constant DMA_CH3_AL3_TRANS_COUNT \ Alias for channel 3 TRANS_COUNT register
$500000FC constant DMA_CH3_AL3_READ_ADDR_TRIG \ Alias for channel 3 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000100 constant DMA_CH4_READ_ADDR \ DMA Channel 4 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000104 constant DMA_CH4_WRITE_ADDR \ DMA Channel 4 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000108 constant DMA_CH4_TRANS_COUNT \ DMA Channel 4 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000010C constant DMA_CH4_CTRL_TRIG \ DMA Channel 4 Control and Status
$50000110 constant DMA_CH4_AL1_CTRL \ Alias for channel 4 CTRL register
$50000114 constant DMA_CH4_AL1_READ_ADDR \ Alias for channel 4 READ_ADDR register
$50000118 constant DMA_CH4_AL1_WRITE_ADDR \ Alias for channel 4 WRITE_ADDR register
$5000011C constant DMA_CH4_AL1_TRANS_COUNT_TRIG \ Alias for channel 4 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000120 constant DMA_CH4_AL2_CTRL \ Alias for channel 4 CTRL register
$50000124 constant DMA_CH4_AL2_TRANS_COUNT \ Alias for channel 4 TRANS_COUNT register
$50000128 constant DMA_CH4_AL2_READ_ADDR \ Alias for channel 4 READ_ADDR register
$5000012C constant DMA_CH4_AL2_WRITE_ADDR_TRIG \ Alias for channel 4 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000130 constant DMA_CH4_AL3_CTRL \ Alias for channel 4 CTRL register
$50000134 constant DMA_CH4_AL3_WRITE_ADDR \ Alias for channel 4 WRITE_ADDR register
$50000138 constant DMA_CH4_AL3_TRANS_COUNT \ Alias for channel 4 TRANS_COUNT register
$5000013C constant DMA_CH4_AL3_READ_ADDR_TRIG \ Alias for channel 4 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000140 constant DMA_CH5_READ_ADDR \ DMA Channel 5 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000144 constant DMA_CH5_WRITE_ADDR \ DMA Channel 5 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000148 constant DMA_CH5_TRANS_COUNT \ DMA Channel 5 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000014C constant DMA_CH5_CTRL_TRIG \ DMA Channel 5 Control and Status
$50000150 constant DMA_CH5_AL1_CTRL \ Alias for channel 5 CTRL register
$50000154 constant DMA_CH5_AL1_READ_ADDR \ Alias for channel 5 READ_ADDR register
$50000158 constant DMA_CH5_AL1_WRITE_ADDR \ Alias for channel 5 WRITE_ADDR register
$5000015C constant DMA_CH5_AL1_TRANS_COUNT_TRIG \ Alias for channel 5 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000160 constant DMA_CH5_AL2_CTRL \ Alias for channel 5 CTRL register
$50000164 constant DMA_CH5_AL2_TRANS_COUNT \ Alias for channel 5 TRANS_COUNT register
$50000168 constant DMA_CH5_AL2_READ_ADDR \ Alias for channel 5 READ_ADDR register
$5000016C constant DMA_CH5_AL2_WRITE_ADDR_TRIG \ Alias for channel 5 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000170 constant DMA_CH5_AL3_CTRL \ Alias for channel 5 CTRL register
$50000174 constant DMA_CH5_AL3_WRITE_ADDR \ Alias for channel 5 WRITE_ADDR register
$50000178 constant DMA_CH5_AL3_TRANS_COUNT \ Alias for channel 5 TRANS_COUNT register
$5000017C constant DMA_CH5_AL3_READ_ADDR_TRIG \ Alias for channel 5 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000180 constant DMA_CH6_READ_ADDR \ DMA Channel 6 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000184 constant DMA_CH6_WRITE_ADDR \ DMA Channel 6 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000188 constant DMA_CH6_TRANS_COUNT \ DMA Channel 6 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000018C constant DMA_CH6_CTRL_TRIG \ DMA Channel 6 Control and Status
$50000190 constant DMA_CH6_AL1_CTRL \ Alias for channel 6 CTRL register
$50000194 constant DMA_CH6_AL1_READ_ADDR \ Alias for channel 6 READ_ADDR register
$50000198 constant DMA_CH6_AL1_WRITE_ADDR \ Alias for channel 6 WRITE_ADDR register
$5000019C constant DMA_CH6_AL1_TRANS_COUNT_TRIG \ Alias for channel 6 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500001A0 constant DMA_CH6_AL2_CTRL \ Alias for channel 6 CTRL register
$500001A4 constant DMA_CH6_AL2_TRANS_COUNT \ Alias for channel 6 TRANS_COUNT register
$500001A8 constant DMA_CH6_AL2_READ_ADDR \ Alias for channel 6 READ_ADDR register
$500001AC constant DMA_CH6_AL2_WRITE_ADDR_TRIG \ Alias for channel 6 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500001B0 constant DMA_CH6_AL3_CTRL \ Alias for channel 6 CTRL register
$500001B4 constant DMA_CH6_AL3_WRITE_ADDR \ Alias for channel 6 WRITE_ADDR register
$500001B8 constant DMA_CH6_AL3_TRANS_COUNT \ Alias for channel 6 TRANS_COUNT register
$500001BC constant DMA_CH6_AL3_READ_ADDR_TRIG \ Alias for channel 6 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500001C0 constant DMA_CH7_READ_ADDR \ DMA Channel 7 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$500001C4 constant DMA_CH7_WRITE_ADDR \ DMA Channel 7 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$500001C8 constant DMA_CH7_TRANS_COUNT \ DMA Channel 7 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$500001CC constant DMA_CH7_CTRL_TRIG \ DMA Channel 7 Control and Status
$500001D0 constant DMA_CH7_AL1_CTRL \ Alias for channel 7 CTRL register
$500001D4 constant DMA_CH7_AL1_READ_ADDR \ Alias for channel 7 READ_ADDR register
$500001D8 constant DMA_CH7_AL1_WRITE_ADDR \ Alias for channel 7 WRITE_ADDR register
$500001DC constant DMA_CH7_AL1_TRANS_COUNT_TRIG \ Alias for channel 7 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500001E0 constant DMA_CH7_AL2_CTRL \ Alias for channel 7 CTRL register
$500001E4 constant DMA_CH7_AL2_TRANS_COUNT \ Alias for channel 7 TRANS_COUNT register
$500001E8 constant DMA_CH7_AL2_READ_ADDR \ Alias for channel 7 READ_ADDR register
$500001EC constant DMA_CH7_AL2_WRITE_ADDR_TRIG \ Alias for channel 7 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500001F0 constant DMA_CH7_AL3_CTRL \ Alias for channel 7 CTRL register
$500001F4 constant DMA_CH7_AL3_WRITE_ADDR \ Alias for channel 7 WRITE_ADDR register
$500001F8 constant DMA_CH7_AL3_TRANS_COUNT \ Alias for channel 7 TRANS_COUNT register
$500001FC constant DMA_CH7_AL3_READ_ADDR_TRIG \ Alias for channel 7 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000200 constant DMA_CH8_READ_ADDR \ DMA Channel 8 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000204 constant DMA_CH8_WRITE_ADDR \ DMA Channel 8 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000208 constant DMA_CH8_TRANS_COUNT \ DMA Channel 8 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000020C constant DMA_CH8_CTRL_TRIG \ DMA Channel 8 Control and Status
$50000210 constant DMA_CH8_AL1_CTRL \ Alias for channel 8 CTRL register
$50000214 constant DMA_CH8_AL1_READ_ADDR \ Alias for channel 8 READ_ADDR register
$50000218 constant DMA_CH8_AL1_WRITE_ADDR \ Alias for channel 8 WRITE_ADDR register
$5000021C constant DMA_CH8_AL1_TRANS_COUNT_TRIG \ Alias for channel 8 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000220 constant DMA_CH8_AL2_CTRL \ Alias for channel 8 CTRL register
$50000224 constant DMA_CH8_AL2_TRANS_COUNT \ Alias for channel 8 TRANS_COUNT register
$50000228 constant DMA_CH8_AL2_READ_ADDR \ Alias for channel 8 READ_ADDR register
$5000022C constant DMA_CH8_AL2_WRITE_ADDR_TRIG \ Alias for channel 8 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000230 constant DMA_CH8_AL3_CTRL \ Alias for channel 8 CTRL register
$50000234 constant DMA_CH8_AL3_WRITE_ADDR \ Alias for channel 8 WRITE_ADDR register
$50000238 constant DMA_CH8_AL3_TRANS_COUNT \ Alias for channel 8 TRANS_COUNT register
$5000023C constant DMA_CH8_AL3_READ_ADDR_TRIG \ Alias for channel 8 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000240 constant DMA_CH9_READ_ADDR \ DMA Channel 9 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000244 constant DMA_CH9_WRITE_ADDR \ DMA Channel 9 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000248 constant DMA_CH9_TRANS_COUNT \ DMA Channel 9 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000024C constant DMA_CH9_CTRL_TRIG \ DMA Channel 9 Control and Status
$50000250 constant DMA_CH9_AL1_CTRL \ Alias for channel 9 CTRL register
$50000254 constant DMA_CH9_AL1_READ_ADDR \ Alias for channel 9 READ_ADDR register
$50000258 constant DMA_CH9_AL1_WRITE_ADDR \ Alias for channel 9 WRITE_ADDR register
$5000025C constant DMA_CH9_AL1_TRANS_COUNT_TRIG \ Alias for channel 9 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000260 constant DMA_CH9_AL2_CTRL \ Alias for channel 9 CTRL register
$50000264 constant DMA_CH9_AL2_TRANS_COUNT \ Alias for channel 9 TRANS_COUNT register
$50000268 constant DMA_CH9_AL2_READ_ADDR \ Alias for channel 9 READ_ADDR register
$5000026C constant DMA_CH9_AL2_WRITE_ADDR_TRIG \ Alias for channel 9 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000270 constant DMA_CH9_AL3_CTRL \ Alias for channel 9 CTRL register
$50000274 constant DMA_CH9_AL3_WRITE_ADDR \ Alias for channel 9 WRITE_ADDR register
$50000278 constant DMA_CH9_AL3_TRANS_COUNT \ Alias for channel 9 TRANS_COUNT register
$5000027C constant DMA_CH9_AL3_READ_ADDR_TRIG \ Alias for channel 9 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000280 constant DMA_CH10_READ_ADDR \ DMA Channel 10 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$50000284 constant DMA_CH10_WRITE_ADDR \ DMA Channel 10 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$50000288 constant DMA_CH10_TRANS_COUNT \ DMA Channel 10 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$5000028C constant DMA_CH10_CTRL_TRIG \ DMA Channel 10 Control and Status
$50000290 constant DMA_CH10_AL1_CTRL \ Alias for channel 10 CTRL register
$50000294 constant DMA_CH10_AL1_READ_ADDR \ Alias for channel 10 READ_ADDR register
$50000298 constant DMA_CH10_AL1_WRITE_ADDR \ Alias for channel 10 WRITE_ADDR register
$5000029C constant DMA_CH10_AL1_TRANS_COUNT_TRIG \ Alias for channel 10 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500002A0 constant DMA_CH10_AL2_CTRL \ Alias for channel 10 CTRL register
$500002A4 constant DMA_CH10_AL2_TRANS_COUNT \ Alias for channel 10 TRANS_COUNT register
$500002A8 constant DMA_CH10_AL2_READ_ADDR \ Alias for channel 10 READ_ADDR register
$500002AC constant DMA_CH10_AL2_WRITE_ADDR_TRIG \ Alias for channel 10 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500002B0 constant DMA_CH10_AL3_CTRL \ Alias for channel 10 CTRL register
$500002B4 constant DMA_CH10_AL3_WRITE_ADDR \ Alias for channel 10 WRITE_ADDR register
$500002B8 constant DMA_CH10_AL3_TRANS_COUNT \ Alias for channel 10 TRANS_COUNT register
$500002BC constant DMA_CH10_AL3_READ_ADDR_TRIG \ Alias for channel 10 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500002C0 constant DMA_CH11_READ_ADDR \ DMA Channel 11 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
$500002C4 constant DMA_CH11_WRITE_ADDR \ DMA Channel 11 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
$500002C8 constant DMA_CH11_TRANS_COUNT \ DMA Channel 11 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
$500002CC constant DMA_CH11_CTRL_TRIG \ DMA Channel 11 Control and Status
$500002D0 constant DMA_CH11_AL1_CTRL \ Alias for channel 11 CTRL register
$500002D4 constant DMA_CH11_AL1_READ_ADDR \ Alias for channel 11 READ_ADDR register
$500002D8 constant DMA_CH11_AL1_WRITE_ADDR \ Alias for channel 11 WRITE_ADDR register
$500002DC constant DMA_CH11_AL1_TRANS_COUNT_TRIG \ Alias for channel 11 TRANS_COUNT register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500002E0 constant DMA_CH11_AL2_CTRL \ Alias for channel 11 CTRL register
$500002E4 constant DMA_CH11_AL2_TRANS_COUNT \ Alias for channel 11 TRANS_COUNT register
$500002E8 constant DMA_CH11_AL2_READ_ADDR \ Alias for channel 11 READ_ADDR register
$500002EC constant DMA_CH11_AL2_WRITE_ADDR_TRIG \ Alias for channel 11 WRITE_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$500002F0 constant DMA_CH11_AL3_CTRL \ Alias for channel 11 CTRL register
$500002F4 constant DMA_CH11_AL3_WRITE_ADDR \ Alias for channel 11 WRITE_ADDR register
$500002F8 constant DMA_CH11_AL3_TRANS_COUNT \ Alias for channel 11 TRANS_COUNT register
$500002FC constant DMA_CH11_AL3_READ_ADDR_TRIG \ Alias for channel 11 READ_ADDR register  This is a trigger register $c. Writing a nonzero value will  reload the channel counter and start the channel.
$50000400 constant DMA_INTR \ Interrupt Status raw
$50000404 constant DMA_INTE0 \ Interrupt Enables for IRQ 0
$50000408 constant DMA_INTF0 \ Force Interrupts
$5000040C constant DMA_INTS0 \ Interrupt Status for IRQ 0
$50000414 constant DMA_INTE1 \ Interrupt Enables for IRQ 1
$50000418 constant DMA_INTF1 \ Force Interrupts for IRQ 1
$5000041C constant DMA_INTS1 \ Interrupt Status masked for IRQ 1
$50000420 constant DMA_TIMER0 \ Pacing X/Y Fractional Timer  The pacing timer produces TREQ assertions at a rate set by X/Y * sys_clk. This equation is evaluated every sys_clk cycles and therefore can only generate TREQs at a rate of 1 per sys_clk i.e. permanent TREQ or less.
$50000424 constant DMA_TIMER1 \ Pacing X/Y Fractional Timer  The pacing timer produces TREQ assertions at a rate set by X/Y * sys_clk. This equation is evaluated every sys_clk cycles and therefore can only generate TREQs at a rate of 1 per sys_clk i.e. permanent TREQ or less.
$50000430 constant DMA_MULTI_CHAN_TRIGGER \ Trigger one or more channels simultaneously
$50000434 constant DMA_SNIFF_CTRL \ Sniffer Control
$50000438 constant DMA_SNIFF_DATA \ Data accumulator for sniff hardware  Write an initial seed value here before starting a DMA transfer on the channel indicated by SNIFF_CTRL_DMACH. The hardware will update this register each time it observes a read from the indicated channel. Once the channel completes, the final result can be read from this register.
$50000440 constant DMA_FIFO_LEVELS \ Debug RAF, WAF, TDF levels
$50000444 constant DMA_CHAN_ABORT \ Abort an in-progress transfer sequence on one or more channels
$50000448 constant DMA_N_CHANNELS \ The number of channels this DMA instance is equipped with. This DMA supports up to 16 hardware channels, but can be configured with as few as one, to minimise silicon area.
$50000800 constant DMA_CH0_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000804 constant DMA_CH0_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000840 constant DMA_CH1_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000844 constant DMA_CH1_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000880 constant DMA_CH2_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000884 constant DMA_CH2_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$500008C0 constant DMA_CH3_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$500008C4 constant DMA_CH3_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000900 constant DMA_CH4_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000904 constant DMA_CH4_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000940 constant DMA_CH5_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000944 constant DMA_CH5_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000980 constant DMA_CH6_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000984 constant DMA_CH6_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$500009C0 constant DMA_CH7_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$500009C4 constant DMA_CH7_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000A00 constant DMA_CH8_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000A04 constant DMA_CH8_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000A40 constant DMA_CH9_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000A44 constant DMA_CH9_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000A80 constant DMA_CH10_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000A84 constant DMA_CH10_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
$50000AC0 constant DMA_CH11_DBG_CTDREQ \ Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
$50000AC4 constant DMA_CH11_DBG_TCR \ Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer

\ =========================== USBCTRL_REGS =========================== \
$50110000 constant USBCTRL_REGS_ADDR_ENDP \ Device address and endpoint control
$50110004 constant USBCTRL_REGS_ADDR_ENDP1 \ Interrupt endpoint 1. Only valid for HOST mode.
$50110008 constant USBCTRL_REGS_ADDR_ENDP2 \ Interrupt endpoint 2. Only valid for HOST mode.
$5011000C constant USBCTRL_REGS_ADDR_ENDP3 \ Interrupt endpoint 3. Only valid for HOST mode.
$50110010 constant USBCTRL_REGS_ADDR_ENDP4 \ Interrupt endpoint 4. Only valid for HOST mode.
$50110014 constant USBCTRL_REGS_ADDR_ENDP5 \ Interrupt endpoint 5. Only valid for HOST mode.
$50110018 constant USBCTRL_REGS_ADDR_ENDP6 \ Interrupt endpoint 6. Only valid for HOST mode.
$5011001C constant USBCTRL_REGS_ADDR_ENDP7 \ Interrupt endpoint 7. Only valid for HOST mode.
$50110020 constant USBCTRL_REGS_ADDR_ENDP8 \ Interrupt endpoint 8. Only valid for HOST mode.
$50110024 constant USBCTRL_REGS_ADDR_ENDP9 \ Interrupt endpoint 9. Only valid for HOST mode.
$50110028 constant USBCTRL_REGS_ADDR_ENDP10 \ Interrupt endpoint 10. Only valid for HOST mode.
$5011002C constant USBCTRL_REGS_ADDR_ENDP11 \ Interrupt endpoint 11. Only valid for HOST mode.
$50110030 constant USBCTRL_REGS_ADDR_ENDP12 \ Interrupt endpoint 12. Only valid for HOST mode.
$50110034 constant USBCTRL_REGS_ADDR_ENDP13 \ Interrupt endpoint 13. Only valid for HOST mode.
$50110038 constant USBCTRL_REGS_ADDR_ENDP14 \ Interrupt endpoint 14. Only valid for HOST mode.
$5011003C constant USBCTRL_REGS_ADDR_ENDP15 \ Interrupt endpoint 15. Only valid for HOST mode.
$50110040 constant USBCTRL_REGS_MAIN_CTRL \ Main control register
$50110044 constant USBCTRL_REGS_SOF_WR \ Set the SOF Start of Frame frame number in the host controller. The SOF packet is sent every 1ms and the host will increment the frame number by 1 each time.
$50110048 constant USBCTRL_REGS_SOF_RD \ Read the last SOF Start of Frame frame number seen. In device mode the last SOF received from the host. In host mode the last SOF sent by the host.
$5011004C constant USBCTRL_REGS_SIE_CTRL \ SIE control register
$50110050 constant USBCTRL_REGS_SIE_STATUS \ SIE status register
$50110054 constant USBCTRL_REGS_INT_EP_CTRL \ interrupt endpoint control register
$50110058 constant USBCTRL_REGS_BUFF_STATUS \ Buffer status register. A bit set here indicates that a buffer has completed on the endpoint if the buffer interrupt is enabled. It is possible for 2 buffers to be completed, so clearing the buffer status bit may instantly re set it on the next clock cycle.
$5011005C constant USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE \ Which of the double buffers should be handled. Only valid if using an interrupt per buffer i.e. not per 2 buffers. Not valid for host interrupt endpoint polling because they are only single buffered.
$50110060 constant USBCTRL_REGS_EP_ABORT \ Device only: Can be set to ignore the buffer control register for this endpoint in case you would like to revoke a buffer. A NAK will be sent for every access to the endpoint until this bit is cleared. A corresponding bit in `EP_ABORT_DONE` is set when it is safe to modify the buffer control register.
$50110064 constant USBCTRL_REGS_EP_ABORT_DONE \ Device only: Used in conjunction with `EP_ABORT`. Set once an endpoint is idle so the programmer knows it is safe to modify the buffer control register.
$50110068 constant USBCTRL_REGS_EP_STALL_ARM \ Device: this bit must be set in conjunction with the `STALL` bit in the buffer control register to send a STALL on EP0. The device controller clears these bits when a SETUP packet is received because the USB spec requires that a STALL condition is cleared when a SETUP packet is received.
$5011006C constant USBCTRL_REGS_NAK_POLL \ Used by the host controller. Sets the wait time in microseconds before trying again if the device replies with a NAK.
$50110070 constant USBCTRL_REGS_EP_STATUS_STALL_NAK \ Device: bits are set when the `IRQ_ON_NAK` or `IRQ_ON_STALL` bits are set. For EP0 this comes from `SIE_CTRL`. For all other endpoints it comes from the endpoint control register.
$50110074 constant USBCTRL_REGS_USB_MUXING \ Where to connect the USB controller. Should be to_phy by default.
$50110078 constant USBCTRL_REGS_USB_PWR \ Overrides for the power signals in the event that the VBUS signals are not hooked up to GPIO. Set the value of the override and then the override enable to switch over to the override value.
$5011007C constant USBCTRL_REGS_USBPHY_DIRECT \ This register allows for direct control of the USB phy. Use in conjunction with usbphy_direct_override register to enable each override bit.
$50110080 constant USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE \ Override enable for each control in usbphy_direct
$50110084 constant USBCTRL_REGS_USBPHY_TRIM \ Used to adjust trim values of USB phy pull down resistors.
$5011008C constant USBCTRL_REGS_INTR \ Raw Interrupts
$50110090 constant USBCTRL_REGS_INTE \ Interrupt Enable
$50110094 constant USBCTRL_REGS_INTF \ Interrupt Force
$50110098 constant USBCTRL_REGS_INTS \ Interrupt status after masking & forcing

\ =========================== PIO0 =========================== \
$50200000 constant PIO0_CTRL \ PIO control register
$50200004 constant PIO0_FSTAT \ FIFO status register
$50200008 constant PIO0_FDEBUG \ FIFO debug register
$5020000C constant PIO0_FLEVEL \ FIFO levels
$50200010 constant PIO0_TXF0 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$50200014 constant PIO0_TXF1 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$50200018 constant PIO0_TXF2 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$5020001C constant PIO0_TXF3 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$50200020 constant PIO0_RXF0 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$50200024 constant PIO0_RXF1 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$50200028 constant PIO0_RXF2 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$5020002C constant PIO0_RXF3 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$50200030 constant PIO0_IRQ \ Interrupt request register. Write 1 to clear
$50200034 constant PIO0_IRQ_FORCE \ Writing a 1 to each of these bits will forcibly assert the corresponding IRQ.  Note this is different to the INTF register: writing here affects PIO internal  state. INTF just asserts the processor-facing IRQ signal for testing ISRs,  and is not visible to the state machines.
$50200038 constant PIO0_INPUT_SYNC_BYPASS \ There is a 2-flipflop synchronizer on each GPIO input, which protects  PIO logic from metastabilities. This increases input delay, and for fast  synchronous IO e.g. SPI these synchronizers may need to be bypassed.  Each bit in this register corresponds to one GPIO.  0 -> input is synchronized default  1 -> synchronizer is bypassed  If in doubt, leave this register as all zeroes.
$5020003C constant PIO0_DBG_PADOUT \ Read to sample the pad output values PIO is currently driving to the GPIOs.
$50200040 constant PIO0_DBG_PADOE \ Read to sample the pad output enables direction PIO is currently driving to the GPIOs.
$50200044 constant PIO0_DBG_CFGINFO \ The PIO hardware has some free parameters that may vary between chip products.  These should be provided in the chip datasheet, but are also exposed here.
$50200048 constant PIO0_INSTR_MEM0 \ Write-only access to instruction memory location 0
$5020004C constant PIO0_INSTR_MEM1 \ Write-only access to instruction memory location 1
$50200050 constant PIO0_INSTR_MEM2 \ Write-only access to instruction memory location 2
$50200054 constant PIO0_INSTR_MEM3 \ Write-only access to instruction memory location 3
$50200058 constant PIO0_INSTR_MEM4 \ Write-only access to instruction memory location 4
$5020005C constant PIO0_INSTR_MEM5 \ Write-only access to instruction memory location 5
$50200060 constant PIO0_INSTR_MEM6 \ Write-only access to instruction memory location 6
$50200064 constant PIO0_INSTR_MEM7 \ Write-only access to instruction memory location 7
$50200068 constant PIO0_INSTR_MEM8 \ Write-only access to instruction memory location 8
$5020006C constant PIO0_INSTR_MEM9 \ Write-only access to instruction memory location 9
$50200070 constant PIO0_INSTR_MEM10 \ Write-only access to instruction memory location 10
$50200074 constant PIO0_INSTR_MEM11 \ Write-only access to instruction memory location 11
$50200078 constant PIO0_INSTR_MEM12 \ Write-only access to instruction memory location 12
$5020007C constant PIO0_INSTR_MEM13 \ Write-only access to instruction memory location 13
$50200080 constant PIO0_INSTR_MEM14 \ Write-only access to instruction memory location 14
$50200084 constant PIO0_INSTR_MEM15 \ Write-only access to instruction memory location 15
$50200088 constant PIO0_INSTR_MEM16 \ Write-only access to instruction memory location 16
$5020008C constant PIO0_INSTR_MEM17 \ Write-only access to instruction memory location 17
$50200090 constant PIO0_INSTR_MEM18 \ Write-only access to instruction memory location 18
$50200094 constant PIO0_INSTR_MEM19 \ Write-only access to instruction memory location 19
$50200098 constant PIO0_INSTR_MEM20 \ Write-only access to instruction memory location 20
$5020009C constant PIO0_INSTR_MEM21 \ Write-only access to instruction memory location 21
$502000A0 constant PIO0_INSTR_MEM22 \ Write-only access to instruction memory location 22
$502000A4 constant PIO0_INSTR_MEM23 \ Write-only access to instruction memory location 23
$502000A8 constant PIO0_INSTR_MEM24 \ Write-only access to instruction memory location 24
$502000AC constant PIO0_INSTR_MEM25 \ Write-only access to instruction memory location 25
$502000B0 constant PIO0_INSTR_MEM26 \ Write-only access to instruction memory location 26
$502000B4 constant PIO0_INSTR_MEM27 \ Write-only access to instruction memory location 27
$502000B8 constant PIO0_INSTR_MEM28 \ Write-only access to instruction memory location 28
$502000BC constant PIO0_INSTR_MEM29 \ Write-only access to instruction memory location 29
$502000C0 constant PIO0_INSTR_MEM30 \ Write-only access to instruction memory location 30
$502000C4 constant PIO0_INSTR_MEM31 \ Write-only access to instruction memory location 31
$502000C8 constant PIO0_SM0_CLKDIV \ Clock divider register for state machine 0  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$502000CC constant PIO0_SM0_EXECCTRL \ Execution/behavioural settings for state machine 0
$502000D0 constant PIO0_SM0_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 0
$502000D4 constant PIO0_SM0_ADDR \ Current instruction address of state machine 0
$502000D8 constant PIO0_SM0_INSTR \ Instruction currently being executed by state machine 0  Write to execute an instruction immediately including jumps and then resume execution.
$502000DC constant PIO0_SM0_PINCTRL \ State machine pin control
$502000E0 constant PIO0_SM1_CLKDIV \ Clock divider register for state machine 1  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$502000E4 constant PIO0_SM1_EXECCTRL \ Execution/behavioural settings for state machine 1
$502000E8 constant PIO0_SM1_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 1
$502000EC constant PIO0_SM1_ADDR \ Current instruction address of state machine 1
$502000F0 constant PIO0_SM1_INSTR \ Instruction currently being executed by state machine 1  Write to execute an instruction immediately including jumps and then resume execution.
$502000F4 constant PIO0_SM1_PINCTRL \ State machine pin control
$502000F8 constant PIO0_SM2_CLKDIV \ Clock divider register for state machine 2  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$502000FC constant PIO0_SM2_EXECCTRL \ Execution/behavioural settings for state machine 2
$50200100 constant PIO0_SM2_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 2
$50200104 constant PIO0_SM2_ADDR \ Current instruction address of state machine 2
$50200108 constant PIO0_SM2_INSTR \ Instruction currently being executed by state machine 2  Write to execute an instruction immediately including jumps and then resume execution.
$5020010C constant PIO0_SM2_PINCTRL \ State machine pin control
$50200110 constant PIO0_SM3_CLKDIV \ Clock divider register for state machine 3  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$50200114 constant PIO0_SM3_EXECCTRL \ Execution/behavioural settings for state machine 3
$50200118 constant PIO0_SM3_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 3
$5020011C constant PIO0_SM3_ADDR \ Current instruction address of state machine 3
$50200120 constant PIO0_SM3_INSTR \ Instruction currently being executed by state machine 3  Write to execute an instruction immediately including jumps and then resume execution.
$50200124 constant PIO0_SM3_PINCTRL \ State machine pin control
$50200128 constant PIO0_INTR \ Raw Interrupts
$5020012C constant PIO0_IRQ0_INTE \ Interrupt Enable for irq0
$50200130 constant PIO0_IRQ0_INTF \ Interrupt Force for irq0
$50200134 constant PIO0_IRQ0_INTS \ Interrupt status after masking & forcing for irq0
$50200138 constant PIO0_IRQ1_INTE \ Interrupt Enable for irq1
$5020013C constant PIO0_IRQ1_INTF \ Interrupt Force for irq1
$50200140 constant PIO0_IRQ1_INTS \ Interrupt status after masking & forcing for irq1

\ =========================== PIO1 =========================== \
$50300000 constant PIO1_CTRL \ PIO control register
$50300004 constant PIO1_FSTAT \ FIFO status register
$50300008 constant PIO1_FDEBUG \ FIFO debug register
$5030000C constant PIO1_FLEVEL \ FIFO levels
$50300010 constant PIO1_TXF0 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$50300014 constant PIO1_TXF1 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$50300018 constant PIO1_TXF2 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$5030001C constant PIO1_TXF3 \ Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
$50300020 constant PIO1_RXF0 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$50300024 constant PIO1_RXF1 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$50300028 constant PIO1_RXF2 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$5030002C constant PIO1_RXF3 \ Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
$50300030 constant PIO1_IRQ \ Interrupt request register. Write 1 to clear
$50300034 constant PIO1_IRQ_FORCE \ Writing a 1 to each of these bits will forcibly assert the corresponding IRQ.  Note this is different to the INTF register: writing here affects PIO internal  state. INTF just asserts the processor-facing IRQ signal for testing ISRs,  and is not visible to the state machines.
$50300038 constant PIO1_INPUT_SYNC_BYPASS \ There is a 2-flipflop synchronizer on each GPIO input, which protects  PIO logic from metastabilities. This increases input delay, and for fast  synchronous IO e.g. SPI these synchronizers may need to be bypassed.  Each bit in this register corresponds to one GPIO.  0 -> input is synchronized default  1 -> synchronizer is bypassed  If in doubt, leave this register as all zeroes.
$5030003C constant PIO1_DBG_PADOUT \ Read to sample the pad output values PIO is currently driving to the GPIOs.
$50300040 constant PIO1_DBG_PADOE \ Read to sample the pad output enables direction PIO is currently driving to the GPIOs.
$50300044 constant PIO1_DBG_CFGINFO \ The PIO hardware has some free parameters that may vary between chip products.  These should be provided in the chip datasheet, but are also exposed here.
$50300048 constant PIO1_INSTR_MEM0 \ Write-only access to instruction memory location 0
$5030004C constant PIO1_INSTR_MEM1 \ Write-only access to instruction memory location 1
$50300050 constant PIO1_INSTR_MEM2 \ Write-only access to instruction memory location 2
$50300054 constant PIO1_INSTR_MEM3 \ Write-only access to instruction memory location 3
$50300058 constant PIO1_INSTR_MEM4 \ Write-only access to instruction memory location 4
$5030005C constant PIO1_INSTR_MEM5 \ Write-only access to instruction memory location 5
$50300060 constant PIO1_INSTR_MEM6 \ Write-only access to instruction memory location 6
$50300064 constant PIO1_INSTR_MEM7 \ Write-only access to instruction memory location 7
$50300068 constant PIO1_INSTR_MEM8 \ Write-only access to instruction memory location 8
$5030006C constant PIO1_INSTR_MEM9 \ Write-only access to instruction memory location 9
$50300070 constant PIO1_INSTR_MEM10 \ Write-only access to instruction memory location 10
$50300074 constant PIO1_INSTR_MEM11 \ Write-only access to instruction memory location 11
$50300078 constant PIO1_INSTR_MEM12 \ Write-only access to instruction memory location 12
$5030007C constant PIO1_INSTR_MEM13 \ Write-only access to instruction memory location 13
$50300080 constant PIO1_INSTR_MEM14 \ Write-only access to instruction memory location 14
$50300084 constant PIO1_INSTR_MEM15 \ Write-only access to instruction memory location 15
$50300088 constant PIO1_INSTR_MEM16 \ Write-only access to instruction memory location 16
$5030008C constant PIO1_INSTR_MEM17 \ Write-only access to instruction memory location 17
$50300090 constant PIO1_INSTR_MEM18 \ Write-only access to instruction memory location 18
$50300094 constant PIO1_INSTR_MEM19 \ Write-only access to instruction memory location 19
$50300098 constant PIO1_INSTR_MEM20 \ Write-only access to instruction memory location 20
$5030009C constant PIO1_INSTR_MEM21 \ Write-only access to instruction memory location 21
$503000A0 constant PIO1_INSTR_MEM22 \ Write-only access to instruction memory location 22
$503000A4 constant PIO1_INSTR_MEM23 \ Write-only access to instruction memory location 23
$503000A8 constant PIO1_INSTR_MEM24 \ Write-only access to instruction memory location 24
$503000AC constant PIO1_INSTR_MEM25 \ Write-only access to instruction memory location 25
$503000B0 constant PIO1_INSTR_MEM26 \ Write-only access to instruction memory location 26
$503000B4 constant PIO1_INSTR_MEM27 \ Write-only access to instruction memory location 27
$503000B8 constant PIO1_INSTR_MEM28 \ Write-only access to instruction memory location 28
$503000BC constant PIO1_INSTR_MEM29 \ Write-only access to instruction memory location 29
$503000C0 constant PIO1_INSTR_MEM30 \ Write-only access to instruction memory location 30
$503000C4 constant PIO1_INSTR_MEM31 \ Write-only access to instruction memory location 31
$503000C8 constant PIO1_SM0_CLKDIV \ Clock divider register for state machine 0  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$503000CC constant PIO1_SM0_EXECCTRL \ Execution/behavioural settings for state machine 0
$503000D0 constant PIO1_SM0_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 0
$503000D4 constant PIO1_SM0_ADDR \ Current instruction address of state machine 0
$503000D8 constant PIO1_SM0_INSTR \ Instruction currently being executed by state machine 0  Write to execute an instruction immediately including jumps and then resume execution.
$503000DC constant PIO1_SM0_PINCTRL \ State machine pin control
$503000E0 constant PIO1_SM1_CLKDIV \ Clock divider register for state machine 1  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$503000E4 constant PIO1_SM1_EXECCTRL \ Execution/behavioural settings for state machine 1
$503000E8 constant PIO1_SM1_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 1
$503000EC constant PIO1_SM1_ADDR \ Current instruction address of state machine 1
$503000F0 constant PIO1_SM1_INSTR \ Instruction currently being executed by state machine 1  Write to execute an instruction immediately including jumps and then resume execution.
$503000F4 constant PIO1_SM1_PINCTRL \ State machine pin control
$503000F8 constant PIO1_SM2_CLKDIV \ Clock divider register for state machine 2  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$503000FC constant PIO1_SM2_EXECCTRL \ Execution/behavioural settings for state machine 2
$50300100 constant PIO1_SM2_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 2
$50300104 constant PIO1_SM2_ADDR \ Current instruction address of state machine 2
$50300108 constant PIO1_SM2_INSTR \ Instruction currently being executed by state machine 2  Write to execute an instruction immediately including jumps and then resume execution.
$5030010C constant PIO1_SM2_PINCTRL \ State machine pin control
$50300110 constant PIO1_SM3_CLKDIV \ Clock divider register for state machine 3  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
$50300114 constant PIO1_SM3_EXECCTRL \ Execution/behavioural settings for state machine 3
$50300118 constant PIO1_SM3_SHIFTCTRL \ Control behaviour of the input/output shift registers for state machine 3
$5030011C constant PIO1_SM3_ADDR \ Current instruction address of state machine 3
$50300120 constant PIO1_SM3_INSTR \ Instruction currently being executed by state machine 3  Write to execute an instruction immediately including jumps and then resume execution.
$50300124 constant PIO1_SM3_PINCTRL \ State machine pin control
$50300128 constant PIO1_INTR \ Raw Interrupts
$5030012C constant PIO1_IRQ0_INTE \ Interrupt Enable for irq0
$50300130 constant PIO1_IRQ0_INTF \ Interrupt Force for irq0
$50300134 constant PIO1_IRQ0_INTS \ Interrupt status after masking & forcing for irq0
$50300138 constant PIO1_IRQ1_INTE \ Interrupt Enable for irq1
$5030013C constant PIO1_IRQ1_INTF \ Interrupt Force for irq1
$50300140 constant PIO1_IRQ1_INTS \ Interrupt status after masking & forcing for irq1

\ =========================== SIO =========================== \
$D0000000 constant SIO_CPUID \ Processor core identifier  Value is 0 when read from processor core 0, and 1 when read from processor core 1.
$D0000004 constant SIO_GPIO_IN \ Input value for GPIO pins
$D0000008 constant SIO_GPIO_HI_IN \ Input value for QSPI pins
$D0000010 constant SIO_GPIO_OUT \ GPIO output value
$D0000014 constant SIO_GPIO_OUT_SET \ GPIO output value set
$D0000018 constant SIO_GPIO_OUT_CLR \ GPIO output value clear
$D000001C constant SIO_GPIO_OUT_XOR \ GPIO output value XOR
$D0000020 constant SIO_GPIO_OE \ GPIO output enable
$D0000024 constant SIO_GPIO_OE_SET \ GPIO output enable set
$D0000028 constant SIO_GPIO_OE_CLR \ GPIO output enable clear
$D000002C constant SIO_GPIO_OE_XOR \ GPIO output enable XOR
$D0000030 constant SIO_GPIO_HI_OUT \ QSPI output value
$D0000034 constant SIO_GPIO_HI_OUT_SET \ QSPI output value set
$D0000038 constant SIO_GPIO_HI_OUT_CLR \ QSPI output value clear
$D000003C constant SIO_GPIO_HI_OUT_XOR \ QSPI output value XOR
$D0000040 constant SIO_GPIO_HI_OE \ QSPI output enable
$D0000044 constant SIO_GPIO_HI_OE_SET \ QSPI output enable set
$D0000048 constant SIO_GPIO_HI_OE_CLR \ QSPI output enable clear
$D000004C constant SIO_GPIO_HI_OE_XOR \ QSPI output enable XOR
$D0000050 constant SIO_FIFO_ST \ Status register for inter-core FIFOs mailboxes.  There is one FIFO in the core 0 -> core 1 direction, and one core 1 -> core 0. Both are 32 bits wide and 8 words deep.  Core 0 can see the read side of the 1->0 FIFO RX, and the write side of 0->1 FIFO TX.  Core 1 can see the read side of the 0->1 FIFO RX, and the write side of 1->0 FIFO TX.  The SIO IRQ for each core is the logical OR of the VLD, WOF and ROE fields of its FIFO_ST register.
$D0000054 constant SIO_FIFO_WR \ Write access to this core's TX FIFO
$D0000058 constant SIO_FIFO_RD \ Read access to this core's RX FIFO
$D000005C constant SIO_SPINLOCK_ST \ Spinlock state  A bitmap containing the state of all 32 spinlocks 1=locked.  Mainly intended for debugging.
$D0000060 constant SIO_DIV_UDIVIDEND \ Divider unsigned dividend  Write to the DIVIDEND operand of the divider, i.e. the p in `p / q`.  Any operand write starts a new calculation. The results appear in QUOTIENT, REMAINDER.  UDIVIDEND/SDIVIDEND are aliases of the same internal register. The U alias starts an  unsigned calculation, and the S alias starts a signed calculation.
$D0000064 constant SIO_DIV_UDIVISOR \ Divider unsigned divisor  Write to the DIVISOR operand of the divider, i.e. the q in `p / q`.  Any operand write starts a new calculation. The results appear in QUOTIENT, REMAINDER.  UDIVIDEND/SDIVIDEND are aliases of the same internal register. The U alias starts an  unsigned calculation, and the S alias starts a signed calculation.
$D0000068 constant SIO_DIV_SDIVIDEND \ Divider signed dividend  The same as UDIVIDEND, but starts a signed calculation, rather than unsigned.
$D000006C constant SIO_DIV_SDIVISOR \ Divider signed divisor  The same as UDIVISOR, but starts a signed calculation, rather than unsigned.
$D0000070 constant SIO_DIV_QUOTIENT \ Divider result quotient  The result of `DIVIDEND / DIVISOR` division. Contents undefined while CSR_READY is low.  For signed calculations, QUOTIENT is negative when the signs of DIVIDEND and DIVISOR differ.  This register can be written to directly, for context save/restore purposes. This halts any  in-progress calculation and sets the CSR_READY and CSR_DIRTY flags.  Reading from QUOTIENT clears the CSR_DIRTY flag, so should read results in the order  REMAINDER, QUOTIENT if CSR_DIRTY is used.
$D0000074 constant SIO_DIV_REMAINDER \ Divider result remainder  The result of `DIVIDEND % DIVISOR` modulo. Contents undefined while CSR_READY is low.  For signed calculations, REMAINDER is negative only when DIVIDEND is negative.  This register can be written to directly, for context save/restore purposes. This halts any  in-progress calculation and sets the CSR_READY and CSR_DIRTY flags.
$D0000078 constant SIO_DIV_CSR \ Control and status register for divider.
$D0000080 constant SIO_INTERP0_ACCUM0 \ Read/write access to accumulator 0
$D0000084 constant SIO_INTERP0_ACCUM1 \ Read/write access to accumulator 1
$D0000088 constant SIO_INTERP0_BASE0 \ Read/write access to BASE0 register.
$D000008C constant SIO_INTERP0_BASE1 \ Read/write access to BASE1 register.
$D0000090 constant SIO_INTERP0_BASE2 \ Read/write access to BASE2 register.
$D0000094 constant SIO_INTERP0_POP_LANE0 \ Read LANE0 result, and simultaneously write lane results to both accumulators POP.
$D0000098 constant SIO_INTERP0_POP_LANE1 \ Read LANE1 result, and simultaneously write lane results to both accumulators POP.
$D000009C constant SIO_INTERP0_POP_FULL \ Read FULL result, and simultaneously write lane results to both accumulators POP.
$D00000A0 constant SIO_INTERP0_PEEK_LANE0 \ Read LANE0 result, without altering any internal state PEEK.
$D00000A4 constant SIO_INTERP0_PEEK_LANE1 \ Read LANE1 result, without altering any internal state PEEK.
$D00000A8 constant SIO_INTERP0_PEEK_FULL \ Read FULL result, without altering any internal state PEEK.
$D00000AC constant SIO_INTERP0_CTRL_LANE0 \ Control register for lane 0
$D00000B0 constant SIO_INTERP0_CTRL_LANE1 \ Control register for lane 1
$D00000B4 constant SIO_INTERP0_ACCUM0_ADD \ Values written here are atomically added to ACCUM0  Reading yields lane 0's raw shift and mask value BASE0 not added.
$D00000B8 constant SIO_INTERP0_ACCUM1_ADD \ Values written here are atomically added to ACCUM1  Reading yields lane 1's raw shift and mask value BASE1 not added.
$D00000BC constant SIO_INTERP0_BASE_1AND0 \ On write, the lower 16 bits go to BASE0, upper bits to BASE1 simultaneously.  Each half is sign-extended to 32 bits if that lane's SIGNED flag is set.
$D00000C0 constant SIO_INTERP1_ACCUM0 \ Read/write access to accumulator 0
$D00000C4 constant SIO_INTERP1_ACCUM1 \ Read/write access to accumulator 1
$D00000C8 constant SIO_INTERP1_BASE0 \ Read/write access to BASE0 register.
$D00000CC constant SIO_INTERP1_BASE1 \ Read/write access to BASE1 register.
$D00000D0 constant SIO_INTERP1_BASE2 \ Read/write access to BASE2 register.
$D00000D4 constant SIO_INTERP1_POP_LANE0 \ Read LANE0 result, and simultaneously write lane results to both accumulators POP.
$D00000D8 constant SIO_INTERP1_POP_LANE1 \ Read LANE1 result, and simultaneously write lane results to both accumulators POP.
$D00000DC constant SIO_INTERP1_POP_FULL \ Read FULL result, and simultaneously write lane results to both accumulators POP.
$D00000E0 constant SIO_INTERP1_PEEK_LANE0 \ Read LANE0 result, without altering any internal state PEEK.
$D00000E4 constant SIO_INTERP1_PEEK_LANE1 \ Read LANE1 result, without altering any internal state PEEK.
$D00000E8 constant SIO_INTERP1_PEEK_FULL \ Read FULL result, without altering any internal state PEEK.
$D00000EC constant SIO_INTERP1_CTRL_LANE0 \ Control register for lane 0
$D00000F0 constant SIO_INTERP1_CTRL_LANE1 \ Control register for lane 1
$D00000F4 constant SIO_INTERP1_ACCUM0_ADD \ Values written here are atomically added to ACCUM0  Reading yields lane 0's raw shift and mask value BASE0 not added.
$D00000F8 constant SIO_INTERP1_ACCUM1_ADD \ Values written here are atomically added to ACCUM1  Reading yields lane 1's raw shift and mask value BASE1 not added.
$D00000FC constant SIO_INTERP1_BASE_1AND0 \ On write, the lower 16 bits go to BASE0, upper bits to BASE1 simultaneously.  Each half is sign-extended to 32 bits if that lane's SIGNED flag is set.
$D0000100 constant SIO_SPINLOCK0 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000104 constant SIO_SPINLOCK1 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000108 constant SIO_SPINLOCK2 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000010C constant SIO_SPINLOCK3 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000110 constant SIO_SPINLOCK4 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000114 constant SIO_SPINLOCK5 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000118 constant SIO_SPINLOCK6 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000011C constant SIO_SPINLOCK7 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000120 constant SIO_SPINLOCK8 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000124 constant SIO_SPINLOCK9 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000128 constant SIO_SPINLOCK10 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000012C constant SIO_SPINLOCK11 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000130 constant SIO_SPINLOCK12 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000134 constant SIO_SPINLOCK13 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000138 constant SIO_SPINLOCK14 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000013C constant SIO_SPINLOCK15 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000140 constant SIO_SPINLOCK16 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000144 constant SIO_SPINLOCK17 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000148 constant SIO_SPINLOCK18 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000014C constant SIO_SPINLOCK19 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000150 constant SIO_SPINLOCK20 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000154 constant SIO_SPINLOCK21 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000158 constant SIO_SPINLOCK22 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000015C constant SIO_SPINLOCK23 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000160 constant SIO_SPINLOCK24 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000164 constant SIO_SPINLOCK25 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000168 constant SIO_SPINLOCK26 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000016C constant SIO_SPINLOCK27 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000170 constant SIO_SPINLOCK28 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000174 constant SIO_SPINLOCK29 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D0000178 constant SIO_SPINLOCK30 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.
$D000017C constant SIO_SPINLOCK31 \ Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is $1 << lock number.

\ =========================== PPB =========================== \
$E000E010 constant PPB_SYST_CSR \ Use the SysTick Control and Status Register to enable the SysTick features.
$E000E014 constant PPB_SYST_RVR \ Use the SysTick Reload Value Register to specify the start value to load into the current value register when the counter reaches 0. It can be any value between 0 and $00FFFFFF. A start value of 0 is possible, but has no effect because the SysTick interrupt and COUNTFLAG are activated when counting from 1 to 0. The reset value of this register is UNKNOWN.  To generate a multi-shot timer with a period of N processor clock cycles, use a RELOAD value of N-1. For example, if the SysTick interrupt is required every 100 clock pulses, set RELOAD to 99.
$E000E018 constant PPB_SYST_CVR \ Use the SysTick Current Value Register to find the current value in the register. The reset value of this register is UNKNOWN.
$E000E01C constant PPB_SYST_CALIB \ Use the SysTick Calibration Value Register to enable software to scale to any required speed using divide and multiply.
$E000E100 constant PPB_NVIC_ISER \ Use the Interrupt Set-Enable Register to enable interrupts and determine which interrupts are currently enabled.  If a pending interrupt is enabled, the NVIC activates the interrupt based on its priority. If an interrupt is not enabled, asserting its interrupt signal changes the interrupt state to pending, but the NVIC never activates the interrupt, regardless of its priority.
$E000E180 constant PPB_NVIC_ICER \ Use the Interrupt Clear-Enable Registers to disable interrupts and determine which interrupts are currently enabled.
$E000E200 constant PPB_NVIC_ISPR \ The NVIC_ISPR forces interrupts into the pending state, and shows which interrupts are pending.
$E000E280 constant PPB_NVIC_ICPR \ Use the Interrupt Clear-Pending Register to clear pending interrupts and determine which interrupts are currently pending.
$E000E400 constant PPB_NVIC_IPR0 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.  Note: Writing 1 to an NVIC_ICPR bit does not affect the active state of the corresponding interrupt.  These registers are only word-accessible
$E000E404 constant PPB_NVIC_IPR1 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
$E000E408 constant PPB_NVIC_IPR2 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
$E000E40C constant PPB_NVIC_IPR3 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
$E000E410 constant PPB_NVIC_IPR4 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
$E000E414 constant PPB_NVIC_IPR5 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
$E000E418 constant PPB_NVIC_IPR6 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
$E000E41C constant PPB_NVIC_IPR7 \ Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
$E000ED00 constant PPB_CPUID \ Read the CPU ID Base Register to determine: the ID number of the processor core, the version number of the processor core, the implementation details of the processor core.
$E000ED04 constant PPB_ICSR \ Use the Interrupt Control State Register to set a pending Non-Maskable Interrupt NMI, set or clear a pending PendSV, set or clear a pending SysTick, check for pending exceptions, check the vector number of the highest priority pended exception, check the vector number of the active exception.
$E000ED08 constant PPB_VTOR \ The VTOR holds the vector table offset address.
$E000ED0C constant PPB_AIRCR \ Use the Application Interrupt and Reset Control Register to: determine data endianness, clear all active state information from debug halt mode, request a system reset.
$E000ED10 constant PPB_SCR \ System Control Register. Use the System Control Register for power-management functions: signal to the system when the processor can enter a low power state, control how the processor enters and exits low power states.
$E000ED14 constant PPB_CCR \ The Configuration and Control Register permanently enables stack alignment and causes unaligned accesses to result in a Hard Fault.
$E000ED1C constant PPB_SHPR2 \ System handlers are a special class of exception handler that can have their priority set to any of the priority levels. Use the System Handler Priority Register 2 to set the priority of SVCall.
$E000ED20 constant PPB_SHPR3 \ System handlers are a special class of exception handler that can have their priority set to any of the priority levels. Use the System Handler Priority Register 3 to set the priority of PendSV and SysTick.
$E000ED24 constant PPB_SHCSR \ Use the System Handler Control and State Register to determine or clear the pending status of SVCall.
$E000ED90 constant PPB_MPU_TYPE \ Read the MPU Type Register to determine if the processor implements an MPU, and how many regions the MPU supports.
$E000ED94 constant PPB_MPU_CTRL \ Use the MPU Control Register to enable and disable the MPU, and to control whether the default memory map is enabled as a background region for privileged accesses, and whether the MPU is enabled for HardFaults and NMIs.
$E000ED98 constant PPB_MPU_RNR \ Use the MPU Region Number Register to select the region currently accessed by MPU_RBAR and MPU_RASR.
$E000ED9C constant PPB_MPU_RBAR \ Read the MPU Region Base Address Register to determine the base address of the region identified by MPU_RNR. Write to update the base address of said region or that of a specified region, with whose number MPU_RNR will also be updated.
$E000EDA0 constant PPB_MPU_RASR \ Use the MPU Region Attribute and Size Register to define the size, access behaviour and memory type of the region identified by MPU_RNR, and enable that region.
