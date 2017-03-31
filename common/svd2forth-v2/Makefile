# Makefile for mecrisp-stellaris svd2forthv2 Quickstart Readme T.Porter 2016
# Requires xsltproc sed vim (or your choice of editor)
  


PROJ    		= ./
FOLDED_SVD  		= STM32F0xx.svd
EDITOR			= gvim
PROCESSOR 		= xsltproc
UNFOLDED_SVD 		= $(FOLDED_SVD).uf.svd
FOLDED_SRC     		= $(PROJ)$(FOLDED_SVD)
UNFOLDED_SRC    	= $(PROJ)$(UNFOLDED_SVD)
UNFOLDER_STYLESHEET	= $(PROJ)svduf.xsl
TEMPLATE_STYLESHEET	= $(PROJ)mk.template.xsl
SVDCUTTER_STYLESHEET	= $(PROJ)svdcutter.xsl  # template.xml is hardcoded here
REGISTERS_STYLESHEET	= $(PROJ)registers.xsl  # template.xml is hardcoded here
TEMPLATE 		= $(PROJ)template.xml
REGISTERS		= $(PROJ)registers.text
MEMMAP			= $(PROJ)m		# full name is memmap.txt but we use "m" to save typing
TEMP			= $(PROJ)1.tmp
TEMP2			= $(PROJ)2.tmp
TEMP3			= $(PROJ)3.tmp
TEMP4			= $(PROJ)4.tmp

all:   memmap


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

$(REGISTERS): $(TEMPLATE) 
	$(PROCESSOR) -o  $(TEMP3) $(REGISTERS_STYLESHEET) $(UNFOLDED_SVD)
	cat $(TEMP3) | sed -e  's/^0x/$$/gi' > $(TEMP4)
	cat $(TEMP4)| sed -e  's/ 0x/ $$/gi' > $(REGISTERS)
	rm $(TEMP3) $(TEMP4)

memmap:	$(TEMPLATE) $(UNFOLDED_SVD) $(REGISTERS)
	$(PROCESSOR) -o $(TEMP) $(SVDCUTTER_STYLESHEET) $(UNFOLDED_SVD)
	cat $(TEMP) | sed -e  's/^0x/$$/gi' > $(TEMP2)
	cat $(TEMP2)| sed -e  's/ 0x/ $$/gi' > $(MEMMAP)
	rm $(TEMP) $(TEMP2)

edit:	$(TEMPLATE)
	$(EDITOR) $(TEMPLATE)

clean:	
	rm $(UNFOLDED_SVD) $(TEMPLATE) $(REGISTERS) $(MEMMAP) .*.swp


 

	
