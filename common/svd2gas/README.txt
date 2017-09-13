SVD2GAS, Copyright Terry Porter 2017 "terry@tjporter.com.au"
This program auto generates equate statements for all registers in a STM32XX for arm-none-eabi-as using CMSIS-SVD
Licensed under the GPL, see http://www.gnu.org/licenses/
Developed on FreeBSD but also tested on a Linux Ubuntu 16.04.1 x64 VM

Howto
=====
* Untar this tarball to a directory
* Save your STM32Fxx.svd in it
* Edit the makefile line "FOLDED_SVD =" to suit your STM32xx.svd
* Run make, and the following files will be created 
a) STM32xx.svd.uf.svd, created from STM32xx.svd
b) template.xml, which is a list of all the registers in your MCU. 
c) STM32Fxx.svd.equ.s containing Bit definitions for fields of width 1, or shifts amounts for fields with a width greather than 1 bit.

Comment out the registers you don't want in template.xml and run make to recreate the STM32Fxx.svd.equ.s file.
==============================================================================================================

How to comment out registers in template.xml ?
==============================================
Not commented out:   <name xmlns:xs="http://www.w3.org/2001/XMLSchema-instance">RCC</name>
Commented out:  <!-- <name xmlns:xs="http://www.w3.org/2001/XMLSchema-instance">RCC</name> -->


Release contents
================
Makefile
mk.template.xsl
README.txt
svduf.xsl
svd2gas.xsl


Dependencies
============
make or gmake
xsltproc
vim (or any editor, change it in the Makefile)

Where to get STM32F SVD files ?
===============================
1) https://github.com/posborne/cmsis-svd
2) arm.com (free account required)

