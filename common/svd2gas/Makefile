# SVD2GAS, Copyright Terry Porter 2017 "terry@tjporter.com.au" for arm-none-eabi-as
# Licensed under the GPL, see http://www.gnu.org/licenses/<

PROJ    		= ./
FOLDED_SVD  		= STM32F0xx.svd
PROCESSOR 		= xsltproc
EDITOR			= gvim -geometry 90x60+150+150
UNFOLDED_SVD 		= $(FOLDED_SVD).uf.svd
FOLDED_SRC     		= $(PROJ)$(FOLDED_SVD)
UNFOLDED_SRC    	= $(PROJ)$(UNFOLDED_SVD)
UNFOLDER_STYLESHEET	= $(PROJ)svduf.xsl
TEMPLATE_STYLESHEET	= $(PROJ)mk.template.xsl
EQUATES_STYLESHEET	= $(PROJ)svd2gas.xsl		# template.xml is hardcoded here
TEMPLATE 		= $(PROJ)template.xml
EQUATES			= $(PROJ)$(FOLDED_SVD).equ.s


all:	$(EQUATES)

$(UNFOLDED_SVD): $(FOLDED_SVD)
	$(PROCESSOR) -o $(UNFOLDED_SVD) $(UNFOLDER_STYLESHEET) $(FOLDED_SVD)
	@echo
	@echo "$(FOLDED_SVD) now unfolded ---> $(UNFOLDED_SVD)"
	@echo
	
$(TEMPLATE): $(UNFOLDED_SVD) $(TEMPLATE_STYLESHEET) $(BITFIELDS_STYLESHEET)
	$(PROCESSOR) -o $(TEMPLATE) $(TEMPLATE_STYLESHEET) $(UNFOLDED_SVD)
	@echo
	@echo "$(UNFOLDED_SVD) template created --> $(TEMPLATE)"
	@echo

$(EQUATES): $(TEMPLATE) $(UNFOLDED_SVD) $(EQUATES_STYLESHEET)
	$(PROCESSOR) -o $(EQUATES) $(EQUATES_STYLESHEET) $(UNFOLDED_SVD)

edit:	$(TEMPLATE)
	$(EDITOR) $(TEMPLATE)

clean:	
	rm .*.swp *.s *.equ.s *.text  
	
distclean: 
	rm .*.swp *.s *.equ.s *.text *.uf.svd template.xml STM32F0xx.svd

 

	
