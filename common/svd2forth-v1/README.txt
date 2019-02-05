svd2forth-v1 by Terry Porter <terry@tjporter.com.au> 2017 for Mecrisp_Stellaris by Mathias Koch
Developed on FreeBSD but also runs on Linux.

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


What is this ?
==============
Svd2forth-v1 uses a ARM CMSIS-SVD XML definition file, to produce a Mecrisp-Stellaris memmory map and Register reference file for the STM32Fx MCU defined in the MAKEFILE.
Svd2forth-v1 creates bare bones, minimal files with no pretty Register printing like svd2forth-v2.

Instructions
============
* Download ALL the SVD files from https://github.com/posborne/cmsis-svd/archive/master.zip (39MB). Svd2forth-v1 is only tested with the STM files and may not work correctly with other non STM32 SVD's.
* Untar svd2forth-v1 to a directory

CHOICE 1
========
* process.sh can be used to process a single SVD or directory full of SVD's with something like :-
"for i in *svd; do ./process.sh $i > ${i%.svd}.fs; done"

* for a single SVD : run "./process.sh STM32x.svd"

The following files will be created :-
   1) "stm32fxx.svd.uf.svd.memmap.fs" is a Forth memory mapped Word list for *every* Register in a STM32F0xx. Upload it to your MCU.
   2) "stm32fxx.svd.uf.svd.register.reference.fs" is a developers reference for every Register and bitfield in a STM32F0xx. This can be searched for Register names in the STM32 pdf's as everyting is CMSIS-SVD compliant, allowing fast configuration without searching endless documentation.


CHOICE 2
========
* Edit Makefile and enter your MCU SVD ( FOLDED_SVD = <your MCU SVD> ). By default STM32F0xx.svd is already entered.
* run (g)make. Two files will be created or remade if they exist.
   1) "stm32fxx.svd.uf.svd.memmap.fs" is a Forth memory mapped Word list for *every* Register in a STM32F0xx. Upload it to your MCU.
   2) "stm32fxx.svd.uf.svd.register.reference.fs" is a developers reference for every Register and bitfield in a STM32F0xx. This can be searched for Register names in the STM32 pdf's as everyting is CMSIS-SVD compliant, allowing fast configuration without searching endless documentation.

* Are *all* the registers too large to upload to your Forth target chip ? Edit template.xml and comment out the registers you don't want
( "<!--    I'm commented out   -->" ) , then run make again, the unwanted registers will be removed, thereby reducing the file size..


Directory contents:-
===================

Dependencies
=============
(g)make
xsltproc
sed


NOTES
=====
* MUST DO: edit the Makefile and replace "STM32F0xx.svd" with the ARM SVD file for your MCU (stm32XX.svd).
* '(g)make clean' will delete the template.xml, stm32fxx.svd.uf.svd.memmap.fs and stm32fxx.svd.uf.svd.register.reference.fs files. Type (g)make to recreate them.


