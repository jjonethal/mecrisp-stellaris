#!/bin/sh
# For use with Mecrisp-Stellaris http://mecrisp.sourceforge.net/
# ARM CMSIS-SVD extractor by Terry Porter "terry@tjporter.com.au"
# Example usage: ./process.sh STM32F0xx.svd
# The example creates four files: template.xml, STM32F0xx.svd.uf.svd, STM32F0xx.svd.uf.svd.memmap.fs, STM32F0xx.svd.uf.svd.register-reference.fs 

echo "parsing your $1"


FOLDED_SVD="$1"
PROCESSOR="xsltproc"
UNFOLDED_SVD="$FOLDED_SVD.uf.svd"
FOLDED_SRC="$FOLDED_SVD"
UNFOLDED_SRC="$UNFOLDED_SVD"
UNFOLDER_STYLESHEET="svduf.xsl"
TEMPLATE_STYLESHEET="mk.template.xsl"
SVDCUTTER_STYLESHEET="svdcutter.xsl"		# template.xml is hard coded here
REGISTERS_STYLESHEET="register-reference.xsl"	# template.xml is hard coded here
TEMPLATE="template.xml"
REGISTERS="register-reference.fs"		# Reference file for the developer
MEMMAP="memmap.fs"				# CMSIS-SVD compliant register memory map		
TEMP="1.tmp"
TEMP2="2.tmp"
TEMP3="3.tmp"
TEMP4="4.tmp"


$PROCESSOR -o $UNFOLDED_SVD $UNFOLDER_STYLESHEET $FOLDED_SVD
	

$PROCESSOR -o $TEMPLATE $TEMPLATE_STYLESHEET $UNFOLDED_SVD

$PROCESSOR -o  $TEMP3 $REGISTERS_STYLESHEET $UNFOLDED_SVD
cat $TEMP3 | sed -e  's/^0x/$$/gi' > $TEMP4
cat $TEMP4 | sed -e  's/ 0x/ $$/gi' > $UNFOLDED_SVD.$REGISTERS
rm $TEMP3 $TEMP4


$PROCESSOR -o $TEMP $SVDCUTTER_STYLESHEET $UNFOLDED_SVD
cat $TEMP | sed -e  's/^0x/$$/gi' > $TEMP2
cat $TEMP2 | sed -e  's/ 0x/ $$/gi' > $UNFOLDED_SVD.$MEMMAP
rm $TEMP $TEMP2

echo "completed processing"
