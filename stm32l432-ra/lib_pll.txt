\
\ 	system clock handling for use HSE or / and PLL
\
\		Ralph Sahli, 2016
\		
\		resources used:
\			
\		REQUIRES: lib_registers.txt

: HSEsysclk ( -- )
	18 bit RCC _rCR bis!					\ HSE crystal oscillator bypass 
	16 bit RCC _rCR bis!					\ HSE clock enable
	begin 17 bit RCC _rCR bit@ until		\ wait for HSE clock ready flag
	
	1 bit RCC _rCFGR bis! 					\ System clock switch: HSE selected as system clock
	begin 3 bit RCC _rCFGR bit@ until		\ HSE oscillator used as system clock

	8000000 hclk !
	115200 baud USART2 _uBRR h! 			\ Set Baud rate divider for 115200 Baud @ HCLK
;
