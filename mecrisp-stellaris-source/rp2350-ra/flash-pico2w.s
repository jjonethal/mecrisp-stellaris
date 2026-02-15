@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@
@    This program is free software: you can redistribute it and/or modify
@    it under the terms of the GNU General Public License as published by
@    the Free Software Foundation, either version 3 of the License, or
@    (at your option) any later version.
@
@    This program is distributed in the hope that it will be useful,
@    but WITHOUT ANY WARRANTY; without even the implied warranty of
@    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
@    GNU General Public License for more details.
@
@    You should have received a copy of the GNU General Public License
@    along with this program.  If not, see <http://www.gnu.org/licenses/>.
@
@ Flash datasheet "D:\prj\rp2350-rppico2\mecrisp-stellaris\mecrisp-stellaris-source\rp2350-ra\doc\W25Q32RV_SPI_QPI RevE 11132025 PlusLZ.pdf"
@ mecrisp-stellaris-source\rp2350-ra\doc\W25Q32RV_SPI_QPI RevE 11132025 PlusLZ.pdf
@ W25Q32RVXHJQ QSPI Flash
@ Commands SPI Mode:
@ 01h  Write Status Register-1 
@ 02h  Page Program 
@ 03h  Read Data 
@ 04h  Write Disable 
@ 05h  Read Status Register-1 
@ 06h  Write Enable 
@ 0Bh  Fast Read 
@ 11h  Write Status Register-3 
@ 15h  Read Status Register-3 
@ 20h  Sector Erase (4KB) 
@ 31h  Write Status Register-2 
@ 35h  Read Status Register-2 
@ 38h  Enter QPI Mode 
@ 42h  Program Security Register(4) 
@ 44h  Erase Security Register(4) 
@ 48h  Read Security Register((4) 
@ 4Bh  Read Unique ID 
@ 50h  Volatile SR Write Enable 
@ 52h  Block Erase (32KB) 
@ 5Ah  Read SFDP Register 
@ 60h  Chip Erase 
@ 66h  Enable Reset 
@ 75h  Erase / Program Suspend 
@ 7Ah  Erase / Program Resume 
@ 90h  Manufacturer/Device ID 
@ 99h  Reset Device 
@ 9Fh  JEDEC ID 
@ ABh  Release Power-down / ID 
@ B9h  Power-down 
@ C0h  Set Read Parameters 
@ C7h  Chip Erase 
@ D8h  Block Erase (64KB)

@ 3Bh Fast Read Dual Output

@ BBh Fast Read Dual I/O
@ 92h Mftr./Device ID Dual I/O

@ 32h Quad Input Page Program
@ 6Bh Fast Read Quad Output

@ 94h Mftr./Device ID Quad I/O
@ EBh Fast Read Quad I/O
@ 77h Set Burst with Wrap




@ 06h Write Enable
@ 50h Volatile SR Write Enable
@ 04h Write Disable
@ ABh Release Power-down / ID
@ 90h Manufacturer/Device ID
@ 9Fh JEDEC ID
@ C0h Set Read Parameters
@ 02h Page Program
@ 20h Sector Erase (4KB)
@ 52h Block Erase (32KB)
@ D8h Block Erase (64KB)

@ 05h Read Status Register-1
@ 01h Write Status Register-1
@ 35h Read Status Register-2
@ 31h Write Status Register-2
@ 15h Read Status Register-3
@ 11h Write Status Register-3
@ B9h Power-down
@ 66h Enable Reset
@ 99h Reset Device
@ FFh Exit QPI Mode


@ 0Bh Fast Read
@ 0Ch Burst Read with Wrap
@ EBh Fast Read Quad I/O

.equ W25Q32RV_CMD_WRITE_STATUS_REG1,        0x01
.equ W25Q32RV_CMD_PAGE_PROGRAM,             0x02
.equ W25Q32RV_CMD_READ_DATA,                0x03
.equ W25Q32RV_CMD_WRITE_DISABLE,            0x04
.equ W25Q32RV_CMD_READ_STATUS_REG1,         0x05
.equ W25Q32RV_CMD_WRITE_ENABLE,             0x06
.equ W25Q32RV_CMD_FAST_READ,                0x0B
.equ W25Q32RV_CMD_WRITE_STATUS_REG3,        0x11
.equ W25Q32RV_CMD_READ_STATUS_REG3,         0x15
.equ W25Q32RV_CMD_SECTOR_ERASE,             0x20
.equ W25Q32RV_CMD_WRITE_STATUS_REG2,        0x31
.equ W25Q32RV_CMD_READ_STATUS_REG2,         0x35
.equ W25Q32RV_CMD_ENTER_QPI_MODE,           0x38
.equ W25Q32RV_CMD_EXIT_QPI_MODE,            0xFF
.equ W25Q32RV_CMD_PROGRAM_SECURITY_REG,     0x42
.equ W25Q32RV_CMD_ERASE_SECURITY_REG,       0x44
.equ W25Q32RV_CMD_READ_SECURITY_REG,        0x48
.equ W25Q32RV_CMD_READ_UNIQUE_ID,           0x4B
.equ W25Q32RV_CMD_VOLATILE_SR_WRITE_ENABLE, 0x50
.equ W25Q32RV_CMD_BLOCK_ERASE_32KB,         0x52
.equ W25Q32RV_CMD_READ_SFDP_REG,            0x5A
.equ W25Q32RV_CMD_CHIP_ERASE,               0x60
.equ W25Q32RV_CMD_ENABLE_RESET,             0x66
.equ W25Q32RV_CMD_ERASE_PROGRAM_SUSPEND,    0x75
.equ W25Q32RV_CMD_ERASE_PROGRAM_RESUME,     0x7A
.equ W25Q32RV_CMD_MANUFACTURER_DEVICE_ID,   0x90
.equ W25Q32RV_CMD_RESET_DEVICE,             0x99
.equ W25Q32RV_CMD_JEDEC_ID,                 0x9F
.equ W25Q32RV_CMD_RELEASE_POWER_DOWN_ID,    0xAB
.equ W25Q32RV_CMD_SET_READ_PARAMETERS,      0xC0
.equ W25Q32RV_CMD_CHIP_ERASE_2,             0xC7
.equ W25Q32RV_CMD_BLOCK_ERASE_64KB,         0xD8

.equ W25Q32RV_CMD_FAST_READ_DUAL_OUTPUT,    0x3B
.equ W25Q32RV_CMD_FAST_READ_DUAL_IO,        0xBB
.equ W25Q32RV_CMD_MF_DEVICE_ID_DUAL_IO,     0x92
.equ W25Q32RV_CMD_QUAD_INPUT_PAGE_PROGRAM,  0x32
.equ W25Q32RV_CMD_FAST_READ_QUAD_OUTPUT,    0x6B
.equ W25Q32RV_CMD_MF_DEVICE_ID_QUAD_IO,     0x94
.equ W25Q32RV_CMD_FAST_READ_QUAD_IO,        0xEB
.equ W25Q32RV_CMD_SET_BURST_WITH_WRAP,      0x77

.equ W25Q32RV_CMD_BURST_READ_WITH_WRAP,     0x0C

@ rp2350 qspi registers
.equ XIP_QMI_BASE, 0x400d0000
  .equ XIP_QMI.DIRECT_CSR, 0x00
    .equ XIP_QMI.DIRECT_CSR.RXDELAY_SHIFT,    30
    .equ XIP_QMI.DIRECT_CSR.RXDELAY_MSK,      (0x03 << XIP_QMI.DIRECT_CSR.RXDELAY_SHIFT) @ Delay the read data sample timing, in units of one half of a system clock cycle.
    .equ XIP_QMI.DIRECT_CSR.CLKDIV_SHIFT,     (22) @ Clock divisor for direct serial mode. (1..255,0:256)
    .equ XIP_QMI.DIRECT_CSR.CLKDIV_MSK,       (0xff << XIP_QMI.DIRECT_CSR.CLKDIV_SHIFT)
    .equ XIP_QMI.DIRECT_CSR.RX_LEVEL_SHIFT,   (18)
    .equ XIP_QMI.DIRECT_CSR.RX_LEVEL_MSK,     (0x07 << XIP_QMI.DIRECT_CSR.RX_LEVEL_SHIFT)
    .equ XIP_QMI.DIRECT_CSR.RXFULL,           (1 << 17)
    .equ XIP_QMI.DIRECT_CSR.RXEMPTY,          (1 << 16)
    .equ XIP_QMI.DIRECT_CSR.TXLEVEL_SHIFT,    (12)
    .equ XIP_QMI.DIRECT_CSR.TXLEVEL_MSK,      (0x07 << XIP_QMI.DIRECT_CSR.TXLEVEL_SHIFT)
    .equ XIP_QMI.DIRECT_CSR.TXEMPTY,          (1 << 11)
    .equ XIP_QMI.DIRECT_CSR.TXFULL,           (1 << 10)
    .equ XIP_QMI.DIRECT_CSR.AUTO_CS1N,        (1 << 7) @ When 1, automatically assert the CS1n chip select line whenever the BUSY flag is set.
    .equ XIP_QMI.DIRECT_CSR.AUTO_CS0N,        (1 << 6) @ When 1, automatically assert the CS0n chip select line whenever the BUSY flag is set.
    .equ XIP_QMI.DIRECT_CSR.ASSERT_CS1N,      (1 << 3) @ When 1, assert (i.e. drive low) the CS1n chip select line. When 0, CS1n driven by chip select logic or AUTO_CS1N. This bit is ignored when AUTO_CS1N is set.
    .equ XIP_QMI.DIRECT_CSR.ASSERT_CS0N,      (1 << 2) @ When 1, assert (i.e. drive low) the CS0n chip select line. When 0, CS0n driven by chip select logic or AUTO_CS0N. This bit is ignored when AUTO_CS0N is set.
    .equ XIP_QMI.DIRECT_CSR.BUSY,             (1 << 1) @ (RO) When 1, a direct transfer is in progress. When 0, the direct transfer engine is idle and ready for the next command.
    .equ XIP_QMI.DIRECT_CSR.EN,               (1 << 0) @ When 1, the direct transfer engine is enabled. When 0, the direct transfer engine is disabled and will ignore writes to the DIRECT_TX register.
  .equ XIP_QMI.DIRECT_TX,  0x04  
    .equ XIP_QMI.DIRECT_TX.NOPUSH,            (1 << 20) @ is set no rx data pushed to rx fifo, otherwise push received data to rx fifo
    .equ XIP_QMI.DIRECT_TX.OE,                (1 << 19) @ ignored for 1 bit transfer, otherwise 0:read, 1: write
    .equ XIP_QMI.DIRECT_TX.DWIDTH,            (1 << 18) @ 0: 8 bit data, 1: 16 bit data
    .equ XIP_QMI.DIRECT_TX.DWIDTH_16_BIT,     (1 << 18) @ 0: 8 bit data, 1: 16 bit data
    .equ XIP_QMI.DIRECT_TX.DWIDTH_8_BIT,      (0 << 18) @ 0: 8 bit data, 1: 16 bit data
    .equ XIP_QMI.DIRECT_TX.IWIDTH_SHIFT,      (16)
    .equ XIP_QMI.DIRECT_TX.IWIDTH_MSK,        (0x03 << XIP_QMI.DIRECT_TX.IWIDTH_SHIFT)
    .equ XIP_QMI.DIRECT_TX.IWIDTH_1_BIT,      (0x00 << XIP_QMI.DIRECT_TX.IWIDTH_SHIFT) @ 0: 1 bit interface
    .equ XIP_QMI.DIRECT_TX.IWIDTH_2_BIT,      (0x01 << XIP_QMI.DIRECT_TX.IWIDTH_SHIFT) @ 1: 2 bit interface
    .equ XIP_QMI.DIRECT_TX.IWIDTH_4_BIT,      (0x02 << XIP_QMI.DIRECT_TX.IWIDTH_SHIFT) @ 2: 4 bit interface
    .equ XIP_QMI.DIRECT_TX.DATA_SHIFT,        (0)
    .equ XIP_QMI.DIRECT_TX.DATA_MSK,          (0xffff << XIP_QMI.DIRECT_TX.DATA_SHIFT)
  .equ XIP_QMI.DIRECT_RX,  0x08
    .equ XIP_QMI.DIRECT_RX.DATA_SHIFT,        (0)
    .equ XIP_QMI.DIRECT_RX.DATA_MSK,          (0xffff << XIP_QMI.DIRECT_RX.DATA_SHIFT)
  .equ XIP_QMI.M0_TIMING,  0x0C
  .equ XIP_QMI.M1_TIMING,  0x20
    .equ XIP_QMI.MX_TIMING.COOLDOWN_SHIFT,    (30)
    .equ XIP_QMI.MX_TIMING.COOLDOWN_MSK,      (0x03 << XIP_QMI.MX_TIMING.COOLDOWN_SHIFT)
    .equ XIP_QMI.MX_TIMING.PAGEBREAK_SHIFT,   (28)
    .equ XIP_QMI.MX_TIMING.PAGEBREAK_MSK,     (0x03 << XIP_QMI.MX_TIMING.PAGEBREAK_SHIFT)
    .equ XIP_QMI.MX_TIMING.SELECT_SETUP,      (1 << 25)
    .equ XIP_QMI.MX_TIMING.SELECT_HOLD_SHIFT, (23)
    .equ XIP_QMI.MX_TIMING.SELECT_HOLD_MSK,   (0x03 << XIP_QMI.MX_TIMING.SELECT_HOLD_SHIFT)
    .equ XIP_QMI.MX_TIMING.MAX_SELECT_SHIFT,  (17)
    .equ XIP_QMI.MX_TIMING.MAX_SELECT_MSK,    (0x3f << XIP_QMI.MX_TIMING.MAX_SELECT_SHIFT)
    .equ XIP_QMI.MX_TIMING.MIN_DESELECT_SHIFT,(12)
    .equ XIP_QMI.MX_TIMING.MIN_DESELECT_MSK,  (0x1f << XIP_QMI.MX_TIMING.MIN_DESELECT_SHIFT)
    .equ XIP_QMI.MX_TIMING.RXDELAY_SHIFT,     (8)
    .equ XIP_QMI.MX_TIMING.RXDELAY_MSK,       (0x07 << XIP_QMI.MX_TIMING.RXDELAY_SHIFT)
    .equ XIP_QMI.MX_TIMING.CLKDIV_SHIFT,      (0)
    .equ XIP_QMI.MX_TIMING.CLKDIV_MSK,        (0xFF << XIP_QMI.MX_TIMING.CLKDIV_SHIFT)
  .equ XIP_QMI.M0_RFMT,    0x10
  .equ XIP_QMI.M1_RFMT,    0x24
    .equ XIP_QMI.MX_RFMT.DTR,                 (1<<28)
    .equ XIP_QMI.MX_RFMT.DUMMY_LEN_SHIFT,     (16)
    .equ XIP_QMI.MX_RFMT.DUMMY_LEN_MSK,       (0x07 << XIP_QMI.MX_RFMT.DUMMY_LEN_SHIFT)
    .equ XIP_QMI.MX_RFMT.SUFFIX_LEN_SHIFT,    (14)
    .equ XIP_QMI.MX_RFMT.SUFFIX_LEN_MSK,      (0x03 << XIP_QMI.MX_RFMT.SUFFIX_LEN_SHIFT)
    .equ XIP_QMI.MX_RFMT.PREFIX_LEN_SHIFT,    (12)
    .equ XIP_QMI.MX_RFMT.PREFIX_LEN_MSK,      (0x01 << XIP_QMI.MX_RFMT.PREFIX_LEN_SHIFT)
    .equ XIP_QMI.MX_RFMT.PREFIX_LEN,          (0x01 << XIP_QMI.MX_RFMT.PREFIX_LEN_SHIFT)
    .equ XIP_QMI.MX_RFMT.DATA_WIDTH_SHIFT,    (8)
    .equ XIP_QMI.MX_RFMT.DATA_WIDTH_MSK,      (0x03 << XIP_QMI.MX_RFMT.DATA_WIDTH_SHIFT)
    .equ XIP_QMI.MX_RFMT.DUMMY_WIDTH_SHIFT,   (6)
    .equ XIP_QMI.MX_RFMT.DUMMY_WIDTH_MSK,     (0x03 << XIP_QMI.MX_RFMT.DUMMY_WIDTH_SHIFT)
    .equ XIP_QMI.MX_RFMT.SUFFIX_WIDTH_SHIFT,  (4)
    .equ XIP_QMI.MX_RFMT.SUFFIX_WIDTH_MSK,    (0x03 << XIP_QMI.MX_RFMT.SUFFIX_WIDTH_SHIFT)
    .equ XIP_QMI.MX_RFMT.ADDR_WIDTH_SHIFT,    (2)
    .equ XIP_QMI.MX_RFMT.ADDR_WIDTH_MSK,      (0x03 << XIP_QMI.MX_RFMT.ADDR_WIDTH_SHIFT)
    .equ XIP_QMI.MX_RFMT.PREFIX_WIDTH_SHIFT,  (0)
    .equ XIP_QMI.MX_RFMT.PREFIX_WIDTH_MSK,    (0x03 << XIP_QMI.MX_RFMT.PREFIX_WIDTH_SHIFT)
  .equ XIP_QMI.M0_RCMD,    0x14
  .equ XIP_QMI.M1_RCMD,    0x28
    .equ XIP_QMI.MX_RCMD.SUFFIX_SHIFT,        (8)
    .equ XIP_QMI.MX_RCMD.SUFFIX_MSK,          (0xFF << XIP_QMI.MX_RCMD.SUFFIX_SHIFT)
    .equ XIP_QMI.MX_RCMD.PREFIX_SHIFT,        (0)
    .equ XIP_QMI.MX_RCMD.PREFIX_MSK,          (0xFF << XIP_QMI.MX_RCMD.PREFIX_SHIFT)
  .equ XIP_QMI.M0_WFMT,    0x18
  .equ XIP_QMI.M1_WFMT,    0x2C
    .equ XIP_QMI.MX_WFMT.DTR_SHIFT,           (28)
    .equ XIP_QMI.MX_WFMT.DTR,                 (1 << XIP_QMI.MX_WFMT.DTR_SHIFT)
    .equ XIP_QMI.MX_WFMT.DUMMY_LEN_SHIFT,     (16)
    .equ XIP_QMI.MX_WFMT.DUMMY_LEN_MSK,       (0x07 << XIP_QMI.MX_WFMT.DUMMY_LEN_SHIFT)
    .equ XIP_QMI.MX_WFMT.SUFFIX_LEN_SHIFT,    (14)
    .equ XIP_QMI.MX_WFMT.SUFFIX_LEN_MSK,      (0x03 << XIP_QMI.MX_WFMT.SUFFIX_LEN_SHIFT)
    .equ XIP_QMI.MX_WFMT.PREFIX_LEN_SHIFT,    (12)
    .equ XIP_QMI.MX_WFMT.PREFIX_LEN_MSK,      (0x01 << XIP_QMI.MX_WFMT.PREFIX_LEN_SHIFT)
    .equ XIP_QMI.MX_WFMT.DATA_WIDTH_SHIFT,    (8)
    .equ XIP_QMI.MX_WFMT.DATA_WIDTH_MSK,      (0x03 << XIP_QMI.MX_WFMT.DATA_WIDTH_SHIFT)
    .equ XIP_QMI.MX_WFMT.DUMMY_WIDTH_SHIFT,   (6)
    .equ XIP_QMI.MX_WFMT.DUMMY_WIDTH_MSK,     (0x03 << XIP_QMI.MX_WFMT.DUMMY_WIDTH_SHIFT)
    .equ XIP_QMI.MX_WFMT.SUFFIX_WIDTH_SHIFT,  (4)
    .equ XIP_QMI.MX_WFMT.SUFFIX_WIDTH_MSK,    (0x03 << XIP_QMI.MX_WFMT.SUFFIX_WIDTH_SHIFT)
    .equ XIP_QMI.MX_WFMT.ADDR_WIDTH_SHIFT,    (2)
    .equ XIP_QMI.MX_WFMT.ADDR_WIDTH_MSK,      (0x03 << XIP_QMI.MX_WFMT.ADDR_WIDTH_SHIFT)
    .equ XIP_QMI.MX_WFMT.PREFIX_WIDTH_SHIFT,  (0)
    .equ XIP_QMI.MX_WFMT.PREFIX_WIDTH_MSK,    (0x03 << XIP_QMI.MX_WFMT.PREFIX_WIDTH_SHIFT)
  .equ XIP_QMI.M0_WCMD,    0x1C
  .equ XIP_QMI.M1_WCMD,    0x30
    .equ XIP_QMI.MX_WCMD.SUFFIX_SHIFT,        (8)
    .equ XIP_QMI.MX_WCMD.SUFFIX_MSK,          (0xFF << XIP_QMI.MX_WCMD.SUFFIX_SHIFT)
    .equ XIP_QMI.MX_WCMD.PREFIX_SHIFT,        (0)
    .equ XIP_QMI.MX_WCMD.PREFIX_MSK,          (0xFF << XIP_QMI.MX_WCMD.PREFIX_SHIFT)
  .equ XIP_QMI.ATRANS0,    0x34
  .equ XIP_QMI.ATRANS1,    0x38
  .equ XIP_QMI.ATRANS2,    0x3C
  .equ XIP_QMI.ATRANS3,    0x40
  .equ XIP_QMI.ATRANS4,    0x44
  .equ XIP_QMI.ATRANS5,    0x48
  .equ XIP_QMI.ATRANS6,    0x4C
  .equ XIP_QMI.ATRANS7,    0x50
    .equ XIP_QMI.ATRANSX.SIZE_SHIFT,          (16)
    .equ XIP_QMI.ATRANSX.SIZE_MSK,            (0x7FF << XIP_QMI.ATRANSX.SIZE_SHIFT)
    .equ XIP_QMI.ATRANSX.BASE_SHIFT,          (0)
    .equ XIP_QMI.ATRANSX.BASE_MSK,            (0xFFF << XIP_QMI.ATRANSX.BASE_SHIFT)

@ atomic register access for register settings
.equ ADR_NORMAL, 0x0000
.equ ADR_XOR,    0x1000
.equ ADR_SET,    0x2000
.equ ADR_CLR,    0x3000

@ top of stack in register tos
@ stack pointer in register psp


@ -----------------------------------------------------------------------------
@ wait until qspi is ready for next command
@ regs used: r0, r1

qmi_wait_ready:
@ -----------------------------------------------------------------------------
    ldr r0, =XIP_QMI_BASE
1:  ldr r1, [r0, #XIP_QMI.DIRECT_CSR]
    tst r1, #XIP_QMI.DIRECT_CSR.BUSY
    bne 1b
    bx lr
.ltorg

@ -----------------------------------------------------------------------------
@ enter XIP mode :
@ Quad enable volatile write enable, then set QE bit in status register 2, then enter QPI mode
@ Volatile write enable: 50h
@ set status bit 9 QE in status register 2: 31h, then write 0x02 to set bit 9
@ set read parameters for QPI mode: C0h, then write 0x30 for 8 (2 mode + 6 dummy) dummy cycles 
@ setting 8 dummy cycles enables 104 MHz none aligned read access in QPI mode, otherwise only 80MHz
@ Enter QIPI Mode: 38h
@ Fast Read Quad I/O: EBh with mode A0h 6 address cycles, 2 mode cycles and 6 dummy cycles

qmi_enter_xip:
    push {r4, lr}
    bl   qmi_wait_ready
    ldr  r2, =XIP_QMI_BASE
    @ volatile status register write enable
    ldr  r3, =(W25Q32RV_CMD_VOLATILE_SR_WRITE_ENABLE | XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (0 << XIP_QMI.DIRECT_TX.IWIDTH_SHIFT))
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    bl   qmi_wait_ready
    @ set QE bit in status register 2
    ldr  r3, =(W25Q32RV_CMD_WRITE_STATUS_REG2 | (0x02 << 8) | XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (XIP_QMI.DIRECT_TX.IWIDTH_1_BIT)  | (XIP_QMI.DIRECT_TX.DWIDTH_16_BIT) )
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    bl   qmi_wait_ready
    @ send C0h,30h to set 8 dummy cycles for QPI mode
    ldr  r3, =(W25Q32RV_CMD_SET_READ_PARAMETERS | (0x30 << 8) | XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (XIP_QMI.DIRECT_TX.IWIDTH_1_BIT) | (XIP_QMI.DIRECT_TX.DWIDTH_16_BIT) )
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    bl   qmi_wait_ready
    @ enter QPI mode send 38h command with 1 bit instruction width, 1 bit data width and no push
    ldr  r3, =(W25Q32RV_CMD_ENTER_QPI_MODE | XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (XIP_QMI.DIRECT_TX.IWIDTH_1_BIT))
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    bl   qmi_wait_ready
    @ switch off direct transfer engine to avoid accidental writes to flash
    ldr  r3, =(XIP_QMI.DIRECT_CSR + ADR_CLR)
    mov  r1, #XIP_QMI.DIRECT_CSR.EN
    str  r1, [r3]
    pop  {r4, pc}
.ltorg

@-----------------------------------------------------------------------------
@ exit XIP mode:
@ enable direct transfer engine, then send FFh command to exit QPI mode
@ After exit QPI mode, flash is in SPI mode with 8 dummy cycles.
@ send FFh exit
@ to make sure flash is in spi mode  transfer 0xFFFF in single io transfer mode.
qmi_exit_xip:
    push {r4, lr}
    bl   qmi_wait_ready
    ldr  r2, =XIP_QMI_BASE
    @ enable direct transfer engine
    ldr  r3, =(XIP_QMI.DIRECT_CSR + ADR_SET)
    mov  r1, #XIP_QMI.DIRECT_CSR.EN
    str  r1, [r3]
    bl   qmi_wait_ready
    @ send FFh command to exit QPI mode with 4 bit instruction width, 4 bit data width and no push
    ldr  r3, =(W25Q32RV_CMD_EXIT_QPI_MODE | XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (XIP_QMI.DIRECT_TX.IWIDTH_4_BIT))
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    bl   qmi_wait_ready
    @ send 0xFFFF in single io mode to make sure flash is in spi mode with 8 dummy cycles
    ldr  r3, =((0xFFFF ) | XIP_QMI.DIRECT_TX.OE | (XIP_QMI.DIRECT_TX.IWIDTH_1_BIT) | (XIP_QMI.DIRECT_TX.DWIDTH_16_BIT) )
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    bl   qmi_wait_ready
    pop {r4, pc}
.ltorg

@ -----------------------------------------------------------------------------
@ Program flash page with data in RAM buffer to address on top of stack
@ data must be located inside flash page, otherwise flash will be corrupted.
@ qspi tx fifo is 4 entries of 8 or 16 bit data, so we can write 4 or 8 bytes at a time depending on data width setting.
@ ( bufferaddress count flashaddr24bit -- )
qmi_program_page:
    push {r4, lr}
    bl   qmi_wait_ready
    bl   qmi_exit_xip @ make sure flash is in spi mode for programming
    bl   qmi_write_enable
    @ send page program command with 1 bit instruction width, 1 bit data width and no push
    ldr  r2, =XIP_QMI_BASE
    ldr  r3, =(W25Q32RV_CMD_PAGE_PROGRAM | XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (XIP_QMI.DIRECT_TX.IWIDTH_1_BIT))
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    mov  r3, tos @ load flash address to r3
    lsr  r3, r3, #16 @ get top byte of flash address for 24 bit addressing
    and  r3, r3, #0xFF @ mask to 8 bit
    @ prepare 8 bit address for page program command, with 1 bit instruction width, 1 bit data width and no push
    ldr  r1, =(XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (XIP_QMI.DIRECT_TX.IWIDTH_1_BIT) | (XIP_QMI.DIRECT_TX.DWIDTH_8_BIT) )
    orr  r3, r3, r1
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    mov  r3, tos @ load flash address to r3
    lsl  r3, r3, #8 @ shift left to get middle byte of flash address for 24 bit addressing
    and  r3, r3, #0xff @ mask to 8 bit
    orr  r3, r3, r1
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write 2nd address byte to direct tx register.
    mov  r3, tos @ load flash address to r3
    and  r3, r3, #0xff @ mask to 8 bit for 24 bit addressing
    orr  r3, r3, r1
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write 3rd address byte to direct tx register.
    mov  r3, tos @ load flash address to r3



@ -----------------------------------------------------------------------------
   Wortbirne Flag_visible, "cflash!" @ ( x Addr -- )
@ top of stack is flash address, next is value to write
c_flashkomma:
@ -----------------------------------------------------------------------------
    push {r4, lr}
    bl   qmi_wait_ready
    ldm  psp!, {r1} @ store byte to write in r1
    movs r0, tos    @ save flash address in r0
    ldr  r2, =XIP_QMI_BASE
    ldr  r3, =(W25Q32RV_CMD_WRITE_ENABLE | XIP_QMI.DIRECT_TX.NOPUSH | XIP_QMI.DIRECT_TX.OE | (0 << XIP_QMI.DIRECT_TX.IWIDTH_SHIFT) | (r1 << XIP_QMI.DIRECT_TX.DATA_SHIFT))
    str  r3, [r2, #XIP_QMI.DIRECT_TX] @ write command to direct tx register
    bl   qmi_wait_ready
    pop {r4, pc}
