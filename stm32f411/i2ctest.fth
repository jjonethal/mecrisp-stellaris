\ i2c tester

i2c-scl
i2c-sda
i2c

: gpio-init                               \ gpio init i2c ports
   0 i2c-scl gpio-pupd!
   0 i2c-scl gpio-mode!
   3 i2c-scl gpio-speed!

   0 i2c-sda gpio-pupd!
   0 i2c-sda gpio-mode!
   3 i2c-sda gpio-speed! ;

: sys-clk-96 ;

: usart-baud  ( usart baud  -- )                    \ set terminal baud rate to 230400
   get-sys-clk 2/ usart-set-baud ;
