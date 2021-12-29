This is a generic STM32 SVD2FORTH By Terry Porter <terry@tjporter.com.au> 2019 for Mecrisp_Stellaris by Mathias Koch
Developed on FreeBSD but will run on other BSD's and Linux. 

Purpose:
========
It uses a MCU CMSIS-SVD file to auto generate every Peripheral and Register memory mapped Word, every Register Bitfield manipulation Word, and every GNU Assembler EQUATE for the *ENTIRE* MCU. This should work on all STM32xxxxx.svd files. It probably won't work with non STM32 CortexM files which have slightly different SVG's.

New: 22June2019, also produced is a STM32xxxxx.svd.equates.s for use with the GNU ASsembler as used with Mecrisp-Stellaris.

Quick Description.
-----------------
This is a 'generic' STM32 release and should work with any STM32xxxxx.svd.

Features:
* memmap.fs file contains all memory mapped peripheral Words and can print all register contents in a group or singly. The print Word for every register has a simple 32 bit legend showing the bit number, this applies to registers which only use 15 bits or different groupings. Both bitfields.fs and memmap.fs now contain description fields parsed from the SVD. Hopefully this will reduce the need to have a databook open while coding.

For instance "rcc." will print every RCC peripheral register.
However "RCC-IOPSMEN." will just print the named register which is part of the RCC group of registers.

* bitfield.fs file contains a Word for each bitfield to be pasted in full or part as desired.

The peripherals contained in either file can be de-selected by commenting out the
peripheral in template.xml as shown in the readme.

* STMxxxxx.svd.equates.s is for use with the GNU ASsembler as used in Mecrisp-Stellaris.

A STM32L07x.svd is included in the tarball for use with the Makefile.


Longer Description
------------------
Memory Map Word Example
-----------------------
$40021000 constant RCC ( Reset and clock control ) 
RCC $0 + constant RCC-CR ( Clock control register ) 
RCC $4 + constant RCC-CFGR ( Clock configuration register  RCC_CFGR ) 
RCC $8 + constant RCC-CIR ( Clock interrupt register  RCC_CIR ) 
RCC $C + constant RCC-APB2RSTR ( APB2 peripheral reset register  RCC_APB2RSTR ) 
RCC $10 + constant RCC-APB1RSTR ( APB1 peripheral reset register  RCC_APB1RSTR ) 
RCC $14 + constant RCC-AHBENR ( AHB Peripheral Clock enable register  RCC_AHBENR ) 
RCC $18 + constant RCC-APB2ENR ( APB2 peripheral clock enable register  RCC_APB2ENR ) 
RCC $1C + constant RCC-APB1ENR ( APB1 peripheral clock enable register  RCC_APB1ENR ) 
RCC $20 + constant RCC-BDCR ( Backup domain control register  RCC_BDCR ) 
RCC $24 + constant RCC-CSR ( Control/status register  RCC_CSR )


1) Peripheral and Register Pretty Printing Legends are separated from the XML file and now contained in a "1b.fs" file.
2) 1b.fs must be loaded first BEFORE memmap.fs
3) Both bitfields.fs and memmap.fs now contain description fields parsed from the SVD. Hopefully this will reduce the need to have a databook open while coding.


Howto
=====
* Include your SVD file in the release directory and edit the SVD name in the Makefile
* run "make everything", this creates template.xml, bitfields.fs, memmap.fs and STMxxxxx.svd.equates.s
* Edit "template.xml" and COMMENT OUT the Peripherals you are NOT using 
   Not commented out:  <name xmlns:xs="http://www.w3.org/2001/XMLSchema-instance">GPIOE</name>
   Commented out:      <!--  <name xmlns:xs="http://www.w3.org/2001/XMLSchema-instance">GPIOE</name> -->   
* run "make mem"
   This will create new bitfields.fs and memmap.fs based on your edited template.xml file.
* Upload 1b.fs then memmap.fs to your MCU. If the Flash or Ram is filled, then perhaps you didn't bother editing template.xml to reduce the size ?
* bitfields.fs are for copy and pasting into your Forth program to configure Register Bitfields.

bitfields.fs
============
There are two types of Bitfields generated:
1) only ONE configuration bit ie
: RCC-CR_HSION   %1 0 lshift RCC-CR bis! ;  \ RCC-CR_HSION    Internal High Speed clock  enable
This type of bitfield will usually SET or CLEAR the one bit with a "bis!" or "bic!" command, or it may possibly be tested with a "bit@" command.

2) More than one configuration bit, ie:
: RCC-CR_HSITRIM   ( %XXXXX -- ) 3 lshift RCC-CR bis! ;  \ RCC-CR_HSITRIM    Internal High Speed clock  trimming
This Bitfield has 5 config bits and can be used this way, which requires the above Word be preloaded:
   %11111 RCC_CR_HSITRIM
Or this way for a standalone config:
   %11111 3 lshift RCC_CR bis!   \ RCC_CR_HSITRIM


Dependencies
=============
make
xsltproc
sed


template.xml
============
    Initially contains a list of ALL the Peripherals in your ARM svd MCU file. You edit this file by either commenting out, or deleting lines of Peripherals you DON'T want to use in your project. 

* Edit "template.xml" and COMMENT OUT the Peripherals you are NOT using 
   Not commented out:  <name xmlns:xs="http://www.w3.org/2001/XMLSchema-instance">GPIOE</name>
   Commented out:      <!--  <name xmlns:xs="http://www.w3.org/2001/XMLSchema-instance">GPIOE</name> -->

Final Notes:
============
ARM CORE Peripherals such as SYSTICK etc are not contained in the CMSIS-SVD's and will need to be manually created.
