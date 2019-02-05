Mecrisp-Stellaris http:// mecrisp.sourceforge.net/ARM CMSIS-SVD register extractor 
Inspired by https://github.com/ralfdoering/cmsis-svd-fth
Copyright (C) 2016  Terry Porter "terry@tjporter.com.au"

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.



Dependencies:-
xlstproc
sed
a unix shell

1. Install the mecrisp-registergenerator tarball content into your working directory

2. chmod +x mecrisp-stellaris-reg_make.sh

3. Download your MCU SVD files from https://github.com/posborne/cmsis-svd/tree/master/data/STMicro
into your working directory


Example usage:        ./mecrisp-stellaris-reg_make.sh STM32F303x.svd

This will produce three files tailored for your STM32 MCU and Mecrisp-Stellaris Forth.
They are designed to assist the development phase, especially if you are new to the MCU.


STM32F303x.svd.reg_memmap.txt    <-- Register memory map

STM32F303x.svd.reg_print.txt     <-- print all contents of any register

STM32F303x.svd.reg_set.txt  <-- Register bits, set with "bis!", clear with "bic!", test with "bit@" etc

They may be copied and pasted, mixed and matched as needed, or uploaded to your MCU in full.
Note the memmap file needs to upload **first** as it has the definitions the other files require.

I don't recommend loading reg_set.txt, its use is as a quick search and template when coding.

