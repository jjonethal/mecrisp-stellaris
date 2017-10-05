\ Copyright Jean Jonethal 2017
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

\ file qspi-hw.fth
\ author jean jonethal
\ qspi flash part N25Q128A13EF840E
\ qspi flash datasheet "C:\Users\jeanjo\Downloads\stm\n25q_128mb_3v_65nm.pdf"
\ https://www.micron.com/~/media/documents/products/data-sheet/nor-flash/serial-nor/n25q/n25q_128mb_3v_65nm.pdf
\ stm32f746 user manual "C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf"


: q4-xip-term ( -- )
   q-init q4 q> -1 qd3! qd2! qd1! qd0! drop
   q-start 
   qc0 qc1  qc0 qc1
   qc0 qc1  qc0 qc1
   qc0 qc1  qc0 qc1
   qc0 qc1  
   ;
: q-reset ( -- )
   q4-xip-term q4-reset-single
   q2-xip-term q2-reset-single
   q1-xip-term q1-reset-single
;