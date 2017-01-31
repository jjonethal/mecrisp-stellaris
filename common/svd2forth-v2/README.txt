Svd2forth-v2 by Terry Porter <terry@tjporter.com.au> 2016 for Mecrisp_Stellaris by Mathias Koch
Developed on FreeBSD but also tested on a Ubuntu 16.04.1 x64 VM


For the Impatient
================
* Untar svd2forth-v2 to a directory
* run make, see what happened, four additional files have been created ?
* "m" is a Forth memory mapped Word list for *every* register in a STM32F0xx
* "registers.text" is a developers reference for every register and bitfield in a STM32F0xx
* don't want *all* the registers as the list is too large to upload to your Forth target chip ? Edit template.xml and comment out the registers you don't want, then run make again.



Directory contents:-
===================
Makefile
README.txt
STM32F0xx.svd (sample ARM svd file. You will need to use a SVD for your own MCU, but use this one to test if this all works for you)
mk.template.xsl
registers.xsl
svdcutter.xsl
svduf.xsl

Dependencies
=============
make
xsltproc
vim (or any editor, change it in the Makefile)
sed

What to Do
==========
* run 'make' in this directory which will create the following four additional files. Note the size of "m" and registers.text
.................................................
"STM32F0xx.svd.uf.svd"
    STM32F0xx.svd that has been 'unfolded'. ARM supply them with missing details for identical registers.

"m"
    The memory mapped Forth file you upload to your target. Initially contains ALL the registers in your MCU and may be too large to upload to your target, depending on Flash size. After template.xml is edited (see below) and make run again, the size of "m" may be drastically reduced.

"registers.text"
    A register and bitfield programmer development reference file for registers selected in template.xml. Initially contains a list of ALL the registers in your ARM svd MCU file.  After template.xml is edited (see below) and make run again, this file will only list the selected registers.

template.xml
    Initially contains a list of ALL the registers in your ARM svd MCU file. You edit this file by either commenting out, or deleting lines
of registers you DON'T want to use in your project. 
...................................................

* edit template.xml with 'make edit'. Either comment out "<--    blah   -->" or delete the entire lines of registers you will not need
* run 'make' again, this will rebuild "M" and "registers.text" to suit the uncommented registers in "template.xml"
* upload "m" to a STM32F0 Discovery board or chip depending on what you're using. Typing 'words' in the serial terminal to your chip wil
  show you the Words available.
* Use "registers.text" as a programming aid by opening it read only and copy/paste register configs to your forth program.

NOTES
=====
* MUST DO: edit the Makefile and replace "STM32F0xx.svd" with the ARM SVD file for your MCU (stm32XX.svd).
* when you use your own stm32XX.svd, edit the xmlns:xs="http://www.w3.org/2001/XMLSchema-instance" line to xmlns:xs="stm32XX" or your template.xml file will be very cluttered
* deleting template.xml and running "make" will recreate the full template.xml file


EXAMPLE
========
Here all but the "COMP" register (as it's so simple)  have been commented out in template.xml and make run. "m" is then uploaded to the MCU.

This is the --- Flash Dictionary --- word list as a result
Address: 00003720 Link: 00004000 Flags: 0000FFFF Code: 00003740 Name: --- Flash Dictionary ---
Address: 00004000 Link: 00004048 Flags: 00000000 Code: 00004010 Name: b32loop.
Address: 00004048 Link: 000040EC Flags: 00000000 Code: 00004052 Name: 1b.
Address: 000040EC Link: 00004148 Flags: 00000000 Code: 000040FA Name: b8loop.
Address: 00004148 Link: 0000419C Flags: 00000000 Code: 00004152 Name: 4b.
Address: 0000419C Link: 000041EC Flags: 00000000 Code: 000041AC Name: b16loop.
Address: 000041EC Link: 00004248 Flags: 00000000 Code: 000041F6 Name: 2b.
Address: 00004248 Link: 00004264 Flags: 00000040 Code: 00004254 Name: COMP
Address: 00004264 Link: 00004284 Flags: 00000040 Code: 00004274 Name: COMP_CSR
Address: 00004284 Link: FFFFFFFF Flags: 00000000 Code: 00004290 Name: COMP.

The word "comp." lists the contents of the COMP_CSR register in the default one bit format (1b.)
comp.
COMP_CSR: 
3|3|2|2|2|2|2|2|2|2|2|2|1|1|1|1|1|1|1|1|1|1
1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0 
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
 ok.

It can be displayed with different print formats:-

comp_csr 2b. 
15|14|13|12|11|10|09|08|07|06|05|04|03|02|01|00 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00

comp_csr 4b. 
 07   06   05   04   03   02   01   00  
0000 0000 0000 0000 0000 0000 0000 0000


Finally let's read the registers.text file which shows how to set any of the bitfields in a copy friendly way
# cat registers.text
      
################################### COMP ###################################
COMP_CSR ()
$00000000 CONSTANT RESET_COMP_CSR 
%1  0 lshift COMP_CSR bis!       \ COMP_COMP1EN		Bit 0    Width 1
%1  1 lshift COMP_CSR bis!       \ COMP_COMP1_INP_DAC	Bit 1    Width 1
%xx  2 lshift COMP_CSR bis!      \ COMP_COMP1MODE	Bit 2    Width 2
%xxx  4 lshift COMP_CSR bis!     \ COMP_COMP1INSEL	Bit 4    Width 3
%xxx  8 lshift COMP_CSR bis!     \ COMP_COMP1OUTSEL	Bit 8    Width 3
%1  11 lshift COMP_CSR bis!      \ COMP_COMP1POL	Bit 11   Width 1
%xx  12 lshift COMP_CSR bis!     \ COMP_COMP1HYST	Bit 12   Width 2
%1  14 lshift COMP_CSR bis!      \ COMP_COMP1OUT	Bit 14   Width 1
%1  15 lshift COMP_CSR bis!      \ COMP_COMP1LOCK	Bit 15   Width 1
%1  16 lshift COMP_CSR bis!      \ COMP_COMP2EN		Bit 16   Width 1
%xx  18 lshift COMP_CSR bis!     \ COMP_COMP2MODE	Bit 18   Width 2
%xxx  20 lshift COMP_CSR bis!    \ COMP_COMP2INSEL	Bit 20   Width 3
%1  23 lshift COMP_CSR bis!      \ COMP_WNDWEN		Bit 23   Width 1
%xxx  24 lshift COMP_CSR bis!    \ COMP_COMP2OUTSEL	Bit 24   Width 3
%1  27 lshift COMP_CSR bis!      \ COMP_COMP2POL	Bit 27   Width 1
%xx  28 lshift COMP_CSR bis!     \ COMP_COMP2HYST	Bit 28   Width 2
%1  30 lshift COMP_CSR bis!      \ COMP_COMP2OUT	Bit 30   Width 1
%1  31 lshift COMP_CSR bis!      \ COMP_COMP2LOCK	Bit 31   Width 1
