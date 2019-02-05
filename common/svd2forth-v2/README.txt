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
    The memory mapped Forth file you upload to your target. Initially contains ALL the registers in your MCU and may be too large to upload to your target, depending on Flash size. After template.xml is edited (see below) and make run again, the size of "m" will be drastically reduced.
Words created in this file are:-
1) Peripheral pretty print words with bit field legends
2) Register pretty print words with bit field legends

"registers.text"
    A register and bitfield programmer development reference file for registers selected in template.xml. Initially contains a list of ALL the registers in your ARM svd MCU file.  After template.xml is edited (see below) and make run again, this file will only list the selected registers.
Words created in this file are:-
1) lshift words for writing to registers
2) Register BitField Fetch Words 

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


