.syntax unified
.cpu cortex-m33
.thumb

.equ SYS_CLK, 150000000 @ System clock frequency in Hz
.equ baudrate, 115200 @ desired baudrate
.equ uartdiv, SYS_CLK / (16 * baudrate)


.data
.align 4
.global baudrate_calc
.global sys_clk
.global uartdiv_calc

uartdiv_calc:
    .word uartdiv
baudrate_calc:
    .word baudrate
sys_clk:
    .word SYS_CLK

