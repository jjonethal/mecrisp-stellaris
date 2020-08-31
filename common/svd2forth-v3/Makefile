# svd2forth-v3 makefile for Mecrisp-Stellaris by Matthias Koch
# By Terry Porter terry@tjporter.com.au

PROJECT_NAME		= svd2forth-v3-stm32
FOLDED_SVD		= STM32L07x.svd
CLEANED_SVD		= $(FOLDED_SVD)-cleaned.svd
UNFOLDED_SVD 		= $(CLEANED_SVD).uf.svd
PROCESSOR 		= xsltproc
EDITOR			= gvim -geometry 90x60+150+150
FOLDED_SRC    		= $(FOLDED_SVD)
UNFOLDER_STY		= svduf.xsl
TEMPLATE_STY		= mk.template.xsl
SVDCUTTER_STY		= svdcutter.xsl  	# template.xml is hardcoded here
BITFIELDS_STY		= bitfields.xsl  	# template.xml is hardcoded here
EQUATES_STY		= svd2gas-equates.xsl   # template.xml is hardcoded here
TEMPLATE		= template.xml
MEMMAP			= memmap.fs		# CMSIS-SVD compliant register memory map
BITFIELDS		= bitfields.fs
TEMP1			= 1.tmp
TEMP2			= 2.tmp
TEMP3			= 3.tmp
TEMP4			= 4.tmp
EQUATES			= $(FOLDED_SVD).equates.s


# upload.main.sh is for use with project-builder-2 only, remove otherwise
all: mem
#all:
#	sh upload.main.sh
help:
	@echo " "
	@echo "===================================== README ================================================"	
	@echo "Please use \`make <target>' where <target> is one of :-"
	@echo "all	   - For use with project-builder-2 only, don't use or comment out otherwise"
	@echo "everything  - Creates template.xml, memmap.fs and bitfields.fs, Use ONCE at start of project"
	@echo "template    - Creates template.xml and will overwrite any existing template.xml edits"
	@echo "mem         - Creates or modifies memmap.fs and bitfields.fs depending on template.cml config"
	@echo "release     - Creates a project release zipfile. note uses VERSION value in Makefile"
	@echo "edit        - Opens template.xml in a editor specified in the Makefile"
	@echo "clean       - removes all created files such as memmap.fs, bitfields.fs"
	@echo "=============================================================================================="

everything: template mem mk.equates

mem: mk.memmap mk.bitfields 

template: mk.template
	
mk.memmap: $(SVDCUTTER_STY) $(TEMPLATE)
	$(PROCESSOR) -o $(TEMP1) $(SVDCUTTER_STY) $(UNFOLDED_SVD)
	cat $(TEMP1) | sed -e  's/^0x/$$/gi' > $(TEMP2)
	cat $(TEMP2) | sed -e  's/ 0x/ $$/gi' > $(MEMMAP)
	rm $(TEMP1) $(TEMP2)

mk.bitfields: $(BITFIELDS_STY) $(TEMPLATE)
	$(PROCESSOR) -o  $(TEMP3) $(BITFIELDS_STY) $(UNFOLDED_SVD)
	cat $(TEMP3) | sed -e  's/^0x/$$/gi' > $(TEMP4)
	cat $(TEMP4)| sed -e  's/ 0x/ $$/gi' > $(BITFIELDS)
	rm $(TEMP3) $(TEMP4)

mk.template: unfold
	$(PROCESSOR) -o $(TEMPLATE) $(TEMPLATE_STY) $(UNFOLDED_SVD)
	@echo
	@echo "$(UNFOLDED_SVD) template created --> $(TEMPLATE)"
	@echo

mk.equates: $(TEMPLATE) $(UNFOLDED_SVD) $(EQUATES_STY)
	$(PROCESSOR) -o $(EQUATES) $(EQUATES_STY) $(UNFOLDED_SVD)	

unfold: svdclean
	$(PROCESSOR) -o $(UNFOLDED_SVD) $(UNFOLDER_STY) $(CLEANED_SVD)
	@echo
	@echo "$(CLEANED_SVD) now unfolded ---> $(UNFOLDED_SVD)"
	@echo

svdclean: $(FOLDED_SVD)
	sh raw-svd-clean.sh $(FOLDED_SVD)

release: 
	fossil zip trunk $(PROJECT_NAME).zip

.PHONY: clean
	
clean:	
	rm $(MEMMAP) $(BITFIELDS) $(TEMPLATE) $(UNFOLDED_SVD) $(CLEANED_SVD) .*.swp 



 

	
