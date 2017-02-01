\ Copyright Jean Jonethal 2015, 2016
\
\ This program is free software: you can redistribute it and/or modify
\ it under the terms of the GNU General Public License as published by
\ the Free Software Foundation, either version 3 of the License, or
\ (at your option) any later version.
\
\ This program is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
\ GNU General Public License for more details.

\ You should have received a copy of the GNU General Public License
\ along with this program.  If not, see <http://www.gnu.org/licenses/>.

\ file robot.fth
\ require util.fth
\ require rcc.fth
\ require display.fth
\ require joystick.fth
\ require qspi.fth


: KBYTE ( n -- n ) 1024 * 1-foldable ;    \ convert kbyte to byte

\ ********** system memory definitions ***

$10000000 CONSTANT SRAM2_START            \ start address of sram2
$10007FFF CONSTANT SRAM2_END              \ end address of sram2
SRAM2_END SRAM2_START - 1 +
          CONSTANT SRAM2_SIZE             \ size of SRAM2
$20000000 CONSTANT SRAM1_START            \ start address of sram1
96 KBYTE  CONSTANT SRAM1_SIZE             \ size of sram1

SRAM1_START SRAM1_SIZE + 1 -
          CONSTANT SRAM1_END              \ end address of sram1

\ ********** L3GD20 Pins *****************

\ http://www.st.com/resource/en/datasheet/l3gd20.pdf

PD1 CONSTANT MEMS_SCK
PD4 CONSTANT MEMS_MOSI
PD3 CONSTANT MEMS_MISO
PD7 CONSTANT GYRO_CS
PB8 CONSTANT GYRO_INT2
PD2 CONSTANT GYRO_INT1

\ ********** LSM303CTR Pins **************

\ http://www.st.com/resource/en/datasheet/lsm303c.pdf
\ C:\Users\jeanjo\Downloads\stm\stm32l476 discovery\en.DM00089896.pdf

PD1 CONSTANT MEMS_SCK
PE0 CONSTANT XL_CS
PC0 CONSTANT MAG_CS
PE1 CONSTANT XL_INT
PD4 CONSTANT MEMS_MOSI
PC2 CONSTANT MAG_RDY
PC1 CONSTANT MAG_INT

\ ********** Robot Feeling ***************

\ robot battery full
\ robot battery low
\ robot battery empty
\ robot happyness
\ robot sadness
\ robot health
\ robot love

\ ********** QSPI Memory *****************

\ N25Q128A13EF840E
\ https://www.micron.com/~/media/documents/products/data-sheet/nor-flash/serial-nor/n25q/n25q_128mb_3v_65nm.pdf
\ C:\Users\jeanjo\Downloads\stm\stm32l476 discovery\n25q_128mb_3v_65nm.pdf
PE11 CONSTANT QSPI_CS                     \ QSPI chip select
PE10 CONSTANT QSPI_CLK                    \ QSPI clock
PE12 CONSTANT QSPI_D0                     \ QSPI data 0
PE13 CONSTANT QSPI_D1                     \ QSPI data 1
PE14 CONSTANT QSPI_D2                     \ QSPI data 2
PE15 CONSTANT QSPI_D3                     \ QSPI data 3


\ ********** SPI sensor driver ***********

: ACCEL-INIT ( -- )
	GYRO-CS-1                             \ deactivate GYRO first
	MEMS-CLK-1                            \ set clock high
	ACCEL-RCC-INIT                        \ turn on accel clock
	ACCEL-GPIO-INIT ;                     \ turn on accel gpio ports
