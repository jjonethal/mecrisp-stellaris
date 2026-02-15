# W25Q32RV commands
## SPI Instructions

|Data Input Output           |Byte 1  |Byte 2      |Byte 3    |Byte 4   |Byte 5      |Byte 6   |Byte 7|
|----                        |----    |----        |----      |----     |----        |----     |----  |
|**Number of Clock(1-1-1)**  |8       |8           |8         |8        |8           |8        |8     |
|Write Enable                |06h     |            |          |         |            |         |      |
|Volatile SR Write Enable    |50h     |            |          |         |            |         |      |
|Write Disable               |04h     |            |          |         |            |         |      |
|Release Power-down / ID     |ABh     |Dummy       |Dummy     |Dummy    |(ID7-ID0)(2)|         |      |
|Manufacturer/Device ID      |90h     |Dummy       |Dummy     |00h      |(MF7-MF0)   |(ID7-ID0)|      |
|JEDEC ID                    |9Fh     |(MF7-MF0)   |(ID15-ID8)|(ID7-ID0)|            |         |      |
|Read Unique ID              |4Bh     |Dummy       |Dummy     |Dummy    |Dummy       |(UID63-0)|      |
|Read Data                   |03h     |A23-A16     |A15-A8    |A7-A0    |(D7-D0)     |         |      |
|Fast Read                   |0Bh     |A23-A16     |A15-A8    |A7-A0    |Dummy       |(D7-D0)  |      |
|Page Program                |02h     |A23-A16     |A15-A8    |A7-A0    |D7-D0       |D7-D0(3) |      |
|Sector Erase (4KB)          |20h     |A23-A16     |A15-A8    |A7-A0    |            |         |      |
|Block Erase (32KB)          |52h     |A23-A16     |A15-A8    |A7-A0    |            |         |      |
|Block Erase (64KB)          |D8h     |A23-A16     |A15-A8    |A7-A0    |            |         |      |
|Chip Erase                  |C7h/60h |            |          |         |            |         |      |
|Read Status Register-1      |05h     |(S7-S0)(2)  |          |         |            |         |      |
|Write Status Register-1     |01h     |(S7-S0)     |          |         |            |         |      |
|Read Status Register-2      |35h     |(S15-S8)(2) |          |         |            |         |      |
|Write Status Register-2     |31h     |(S15-S8)    |          |         |            |         |      |
|Read Status Register-3      |15h     |(S23-S16)(2)|          |         |            |         |      |
|Write Status Register-3     |11h     |(S23-S16)   |          |         |            |         |      |
|Read SFDP Register          |5Ah     |A23-A16     |A15-A8    |A7-A0    |Dummy       |(D7-D0)  |      |
|Erase Security Register(4)  |44h     |A23-A16     |A15-A8    |A7-A0    |            |         |      |
|Program Security Register(4)|42h     |A23-A16     |A15-A8    |A7-A0    |D7-D0       |D7-D0(3) |      |
|Read Security Register(4)   |48h     |A23-A16     |A15-A8    |A7-A0    |Dummy       |(D7-D0)  |      |
|Erase / Program Suspend     |75h     |            |          |         |            |         |      |
|Erase / Program Resume      |7Ah     |            |          |         |            |         |      |
|Power-down                  |B9h     |            |          |         |            |         |      |
|Set Read Parameters         |C0h     |P7-P0       |          |         |            |         |      |
|Enter QPI Mode              |38h     |            |          |         |            |         |      |
|Enable Reset                |66h     |            |          |         |            |         |      |
|Reset Device                |99h     |            |          |         |            |         |      |

## Instruction Set Table 2 (Dual/Quad SPI Instructions) (1)
|Data Input Output         |Byte 1 |Byte 2     |Byte 3    |Byte 4  |Byte 5    |Byte 6      |Byte 7      |Byte 8   |Byte 9    |
|----                      |----   |-------    |-------   |------- |-------   |-------     |-------     |-------  |------    |
|**Number of Clock(1-1-2)**|8      |8          |8         |8       |4         |4           |4           |4        |4         |
|Fast Read Dual Output     |3Bh    |A23-A16    |A15-A8    |A7-A0   |Dummy     |Dummy       |(D7-D0)(6)  |…        |          |
|**Number of Clock(1-2-2)**|8      |4          |4         |4       |4         |4           |4           |4        |4         |
|Fast Read Dual I/O        |BBh    |A23-A16(5) |A15-A8(5) |A7-A0(5)|M7-M0     |(D7-D0)(6)  |…           |         |          |
|Mftr./Device ID Dual I/O  |92h    |A23-A16(5) |A15-A8(5) |00(5)   |Dummy(17) |(MF7-MF0)(6)|(ID7-ID0)(6)|         |          |
|**Number of Clock(1-1-4)**|8      |8          |8         |8       |2         |2           |2           |2        |2         |
|Quad Input Page Program   |32h    |A23-A16    |A15-A8    |A7-A0   |(D7-D0)(8)|(D7-D0)(3)  |…           |         |          |
|Fast Read Quad Output     |6Bh    |A23-A16    |A15-A8    |A7-A0   |Dummy     |Dummy       |Dummy       |Dummy    |(D7-D0)(9)|
|**Number of Clock(1-4-4)**|8      |2(7)       |2(7)      |2(7)    |2         |2           |2           |2        |2         |
|Mftr./Device ID Quad I/O  |94h    |A23-A16    |A15-A8    |00      |Dummy(13) |Dummy       |Dummy       |(MF7-MF0)|(ID7-ID0) |
|Fast Read Quad I/O        |EBh    |A23-A16    |A15-A8    |A7-A0   |M7-M0(13) |Dummy(11)   |Dummy(11)   |(D7-D0)  |…         |
|Set Burst with Wrap       |77h    |Dummy      |Dummy     |Dummy   |W7-W0     |            |            |         |          |

## Instruction Set Table 3 (QPI Instructions)(10) W25Q32RV
|Data Input Output          |Byte 1  |Byte 2      |Byte 3     |Byte 4    |Byte 5       |Byte 6    |Byte 7 |
|----                       |----    |----        |----       |----      |----         |----      |----   |
|**Number of Clock (4-4-4)**|2       |2           |2          |2         |2            |2         |2      |
|Write Enable               |06h     |            |           |          |             |          |       |
|Volatile SR Write Enable   |50h     |            |           |          |             |          |       |
|Write Disable              |04h     |            |           |          |             |          |       |
|Release Power-down / ID    |ABh     |Dummy       |Dummy      |Dummy     |(ID7-ID0)(2) |          |       |
|Manufacturer/Device ID     |90h     |Dummy       |Dummy      |00h       |(MF7-MF0)    |(ID7-ID0) |       |
|JEDEC ID                   |9Fh     |(MF7-MF0)   |(ID15-ID8) |(ID7-ID0) |             |          |       |
|Set Read Parameters        |C0h     |P7-P0       |           |          |             |          |       |
|Page Program               |02h     |A23-A16     |A15-A8     |A7-A0     |D7-D0(9)     |D7-D0(3)  |…      |
|Sector Erase (4KB)         |20h     |A23-A16     |A15-A8     |A7-A0     |             |          |       |
|Block Erase (32KB)         |52h     |A23-A16     |A15-A8     |A7-A0     |             |          |       |
|Block Erase (64KB)         |D8h     |A23-A16     |A15-A8     |A7-A0     |             |          |       |
|Chip Erase                 |C7h/60h |            |           |          |             |          |       |
|Read Status Register-1     |05h     |(S7-S0)(2)  |           |          |             |          |       |
|Write Status Register-1    |01h     |(S7-S0)     |           |          |             |          |       |
|Read Status Register-2     |35h     |(S15-S8)(2) |           |          |             |          |       |
|Write Status Register-2    |31h     |(S15-S8)    |           |          |             |          |       |
|Read Status Register-3     |15h     |(S23-S16)(2)|           |          |             |          |       |
|Write Status Register-3    |11h     |(S23-S16)   |           |          |             |          |       |
|Power-down                 |B9h     |            |           |          |             |          |       |
|Enable Reset               |66h     |            |           |          |             |          |       |
|Reset Device               |99h     |            |           |          |             |          |       |
|Exit QPI Mode              |FFh     |            |           |          |             |          |       |


|Data Input Output          |Byte 1 |Byte 2 |Byte 3 |Byte 4 |Byte 5   |Byte 6   |Byte 7 |
|----                       |----   |----   |----   |----   |----     |----     |----   |
|**Number of Clock (4-4-4)**|2      |2      |2      |2      |2        |4        |2      |
|Fast Read                  |0Bh    |A23-A16|A15-A8 |A7-A0  |Dummy    |Dummy(11)|(D7-D0)|
|Burst Read with Wrap       |0Ch    |A23-A16|A15-A8 |A7-A0  |Dummy    |Dummy(11)|(D7-D0)|
|Fast Read Quad I/O         |EBh    |A23-A16|A15-A8 |A7-A0  |M7-M0(13)|Dummy(11)|(D7-D0)|