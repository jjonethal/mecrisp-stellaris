# svd2forth-v2 makefile for Mecrisp-Stellaris by Matthias Koch
# By Terry Porter terry@tjporter.com.au

PROJ    		= ./
FOLDED_SVD  		= STM32F0xx.svd
PROCESSOR 		= xsltproc
EDITOR			= gvim -geometry 90x60+150+150
UNFOLDED_SVD 		= $(FOLDED_SVD).uf.svd
FOLDED_SRC     		= $(PROJ)$(FOLDED_SVD)
UNFOLDED_SRC    	= $(PROJ)$(UNFOLDED_SVD)
UNFOLDER_STYLESHEET	= $(PROJ)svduf.xsl
TEMPLATE_STYLESHEET	= $(PROJ)mk.template.xsl
SVDCUTTER_STYLESHEET	= $(PROJ)svdcutter.xsl  	# template.xml is hard coded here
REGISTERS_STYLESHEET	= $(PROJ)register-reference.xsl # template.xml is hard coded here
TEMPLATE 		= $(PROJ)template.xml
REGISTERS		= $(PROJ)$(UNFOLDED_SVD).register-reference.fs	# Reference file for the developer
MEMMAP			= $(PROJ)$(UNFOLDED_SVD).memmap.fs		# CMSIS-SVD compliant register memory map		
TEMP			= $(PROJ)1.tmp
TEMP2			= $(PROJ)2.tmp
TEMP3			= $(PROJ)3.tmp
TEMP4			= $(PROJ)4.tmp

all:  $(MEMMAP)  $(REGISTERS)


$(UNFOLDED_SVD): $(FOLDED_SVD)
	$(PROCESSOR) -o $(UNFOLDED_SVD) $(UNFOLDER_STYLESHEET) $(FOLDED_SVD)
	@echo
	@echo "$(FOLDED_SVD) now unfolded ---> $(UNFOLDED_SVD)"
	@echo
	
$(TEMPLATE): $(UNFOLDED_SVD)
	$(PROCESSOR) -o $(TEMPLATE) $(TEMPLATE_STYLESHEET) $(UNFOLDED_SVD)
	@echo
	@echo "$(UNFOLDED_SVD) template created --> $(TEMPLATE)"
	@echo

$(REGISTERS): $(TEMPLATE) $(UNFOLDED_SVD) $(REGISTERS_STYLESHEET)
	$(PROCESSOR) -o  $(TEMP3) $(REGISTERS_STYLESHEET) $(UNFOLDED_SVD)
	cat $(TEMP3) | sed -e  's/^0x/$$/gi' > $(TEMP4)
	cat $(TEMP4)| sed -e  's/ 0x/ $$/gi' > $(REGISTERS)
	rm $(TEMP3) $(TEMP4)

$(MEMMAP): $(TEMPLATE) $(UNFOLDED_SVD) $(SVDCUTTER_STYLESHEET)
	$(PROCESSOR) -o $(TEMP) $(SVDCUTTER_STYLESHEET) $(UNFOLDED_SVD)
	cat $(TEMP) | sed -e  's/^0x/$$/gi' > $(TEMP2)
	cat $(TEMP2)| sed -e  's/ 0x/ $$/gi' > $(MEMMAP)
	rm $(TEMP) $(TEMP2)

edit:	$(TEMPLATE)
	$(EDITOR) $(TEMPLATE)

clean:	
	rm $(MEMMAP) $(REGISTERS) $(TEMPLATE) $(UNFOLDED_SVD) .*.swp



 

	
