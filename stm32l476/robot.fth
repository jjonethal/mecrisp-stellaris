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

$10000000 CONSTANT SRAM2_START            \ start address of sram2
$10007FFF CONSTANT SRAM2_END              \ end address of sram2
$20000000 CONSTANT SRAM1_START            \ start address of sram1
96 KBYTE  CONSTANT SRAM1_SIZE             \ size of sram1

SRAM1_START SRAM1_SIZE + 1 -
          CONSTANT SRAM1_END              \ end address of sram1
