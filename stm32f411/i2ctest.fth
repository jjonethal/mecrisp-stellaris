\ i2c tester


: gpio-init
 i2c-clk gpio-input
 i2c-clk gpio-open-drain
 i2c-clk gpio-fast
 i2c-sda gpio-input
 i2c-sda gpio-open-drain
 i2c-sda gpio-fast

: sys-clk-100 ;

: usart-230400
