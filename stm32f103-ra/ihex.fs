\ Program Name: ihex.fs
\ Date: Sun 5 Jan 2020 21:19:51 AEDT
\ Copyright 2020 by t.j.porter <terry@tjporter.com.au>, licensed under the GPLV2
\ For Mecrsp-Stellars by Matthas Koch.
\ https://sourceforge.net/projects/mecrisp/
\ MCU: STM32Fxxx
\ This Forth Program : Dumps a iHex image of the target MCU dictionary to the
\ terminal where it can be captured in a terminal log and turned into a 
\ bootable binary file clone of the target.
\ ---------------------------------------------------------------------------------------\
\
\     Usage:    "1|2 flash-size-register-address clone"
\
\     '1' = normal use
\
\     '2' = only for a STM32F103C8 which reports 64kB of Flash but actually has double (128kB)
\     OR if you suspect your chip MAY have double the flash advertized. Note: will crash
\     this program with a Exception if it doesn't!
\
\     'flash-size-register-address' = "Flash size data register address". Check your STM
\     reference manual "Device electronic signature" section.
\
\     'clone' name of the program as listed below in the source
\
\     Example usage for:
\     STM32F051:     "1 $1FFFF7CC clone"
\     STM32F103CB:   "1 $1FFFF7E0 clone"
\     STM32F103C8:   "2 $1FFFF7E0 clone" 
\ 
\ The iHex dump starts with the word "clone" and ends with the word "clone_end" for
\ easy parsing to remove any extraneous text before using 'arm-none-eabi-objcopy'.
\ 
\ Once you have the iHex File process it as below.
\
\ " arm-none-eabi-objcopy -I ihex -O binary <your-iHex-logfile> <binaryfile-name.bin> "
\ ---------------------------------------------------------------------------------------\
\ Notes:
\ Can produce extended iHex files up to 32 bits, i.e. 4 GB.
\ iHex Extended Addressing type 04 is used
\ ihex.fs reads the STM32 MCU "Flash Size Register" to determine the maximum size and won't
\ attempt to read beyond that because a Exception may be thrown if it is the Flash end.
\ Check your STM reference manual for your MCU's "Flash Size Register" address.
\
\ flash-size-register-address	 MCU
\ ---------------------------    ----------
\ $1FFFF7CC			 STM32F0XX
\ $1FFFF7E0			 STM32F1XX 
\ $1FFF7A22			 STM32F405/415, STM32F407/417, STM32F427/437 and STM32F429/439		 
\ -------------------- Shouldn't need to change anything below ------------------------- \

 : erased? ( -- )    \ Check Flash bytes NOT erased.
   0		      \ Flag of 0 = erased byte, ignore data afterwards
   i 16 + i do	       \ Scan data
      i c@ $FF <> or	\ Set flag if there is a non-$FF byte. Some chips have Flash = $00 as erased.
   loop
 ; 

 : ea04generate ( -- print 04 Extended Address Type record )
   ." :02000004"	      \ Write 04 Extended Address Type record preamble
   dup h.4		       \ quotient = LBA
   $06 + not $FF and 1 +        \ calculate checksum. $06 is record preamble value.
   h.2	cr		         \ print checksum
 ;

 : insert.04ea? ( 32 bit hex address  -- 04 Extended Address iHex Type records )
      i $10000 >= IF	      \ eliminate addresses under 64kB  ($10000)
        i $10000 u/mod	       \ quotient is TOS, then remainder
        swap		        
	   0= IF		 \ only want values where there is no remainder
	      ea04generate	  \ quotient passed to ea04generate as LBA
	   ELSE drop		   \ drop unwanted non zero remainder
	   THEN	  		 
      THEN
 ;

 : clone ( 1|2 flash-size-register-address -- ) cr	\ Dumps a bootable Flash Image (core + all words)
   @ $FFFF and 1024 * *	       \ calculate flash size
      0 do   
	 erased?
	 if
	    insert.04ea?  
	    ." :10" i h.4 ." 00"    \ Write record-intro with 4 digits
	    $10			     \ Begin checksum
	    i          $FF and +      \ Sum the address bytes 
	    i 8 rshift $FF and +       \ separately into the checksum
	    i 16 + i do		        \ EOL		    
	       i c@ h.2		         \ Print data with 2 digits
	       i c@ +			  \ Sum it up for Checksum
	       loop		     
	    negate h.2			    \ Write Checksum
	    cr			       
	 then				      \ End of Flash or area of erased bytes ( $FFFF )    
      16 +loop 
   ." :00000001FF "				\ iHex terminator
   ." clone_end " cr				 \ clone.sh search log terminator
 ;
