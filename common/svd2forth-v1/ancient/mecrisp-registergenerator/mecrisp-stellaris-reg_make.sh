#!/bin/sh
## Mecrisp-Stellaris http://mecrisp.sourceforge.net/
## ARM CMSIS-SVD extractor by Terry Porter "terry@tjporter.com.au"
## Example usage: ./mecrisp-stellaris-reg_make.sh STM32F303x.svd

echo "parsing your $1"
xsltproc -o $1.reg_memmap.txt.tmp ./mecrisp-stellaris-reg_memmap.xsl $1
xsltproc -o $1.reg_print.txt.tmp ./mecrisp-stellaris-reg_print.xsl $1
xsltproc -o $1.reg_set.txt.tmp ./mecrisp-stellaris-reg_set.xsl $1

cat $1.reg_memmap.txt.tmp | sed -e 's/0x/\$/gi' > $1.reg_memmap.txt
cat $1.reg_print.txt.tmp | sed -e 's/0x/\$/gi' > $1.reg_print.txt
cat $1.reg_set.txt.tmp | sed -e 's/0x/\$/gi' > $1.reg_set.txt
rm $1.reg_memmap.txt.tmp $1.reg_print.txt.tmp $1.reg_set.txt.tmp

echo "completed processing"
