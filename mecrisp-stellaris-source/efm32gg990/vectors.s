@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@
@    This program is free software: you can redistribute it and/or modify
@    it under the terms of the GNU General Public License as published by
@    the Free Software Foundation, either version 3 of the License, or
@    (at your option) any later version.
@
@    This program is distributed in the hope that it will be useful,
@    but WITHOUT ANY WARRANTY; without even the implied warranty of
@    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
@    GNU General Public License for more details.
@
@    You should have received a copy of the GNU General Public License
@    along with this program.  If not, see <http://www.gnu.org/licenses/>.
@

@ -----------------------------------------------------------------------------
@ Interruptvektortabelle
@ -----------------------------------------------------------------------------

.include "../common/vectors-common.s"

@ Special interrupt handlers for this particular chip:

.word irq_vektor_dma+1       @  DMA_IRQHandler         ; 0: DMA Interrupt
.word irq_vektor_gpioeven+1  @  GPIO_EVEN_IRQHandler   ; 1: GPIO_EVEN Interrupt
.word irq_vektor_timer0+1    @  TIMER0_IRQHandler      ; 2: TIMER0 Interrupt
.word irq_vektor_usart0rx+1  @  USART0_RX_IRQHandler   ; 3: USART0_RX Interrupt
.word irq_vektor_usart0tx+1  @  USART0_TX_IRQHandler   ; 4: USART0_TX Interrupt
.word irq_vektor_acmp0+1     @  ACMP0_IRQHandler       ; 5: ACMP0 Interrupt
.word irq_vektor_adc0+1      @  ADC0_IRQHandler        ; 6: ADC0 Interrupt
.word irq_vektor_dac0+1      @  DAC0_IRQHandler        ; 7: DAC0 Interrupt
.word irq_vektor_i2c0+1      @  I2C0_IRQHandler        ; 8: I2C0 Interrupt
.word irq_vektor_gpioodd+1   @  GPIO_ODD_IRQHandler    ; 9: GPIO_ODD Interrupt
.word irq_vektor_timer1+1    @  TIMER1_IRQHandler      ; 10: TIMER1 Interrupt
.word irq_vektor_timer2+1    @  TIMER2_IRQHandler      ; 11: TIMER2 Interrupt
.word irq_vektor_usart1rx+1  @  USART1_RX_IRQHandler   ; 12: USART1_RX Interrupt
.word irq_vektor_usart1tx+1  @  USART1_TX_IRQHandler   ; 13: USART1_TX Interrupt
.word irq_vektor_usart2rx+1  @  USART2_RX_IRQHandler   ; 14: USART2_RX Interrupt
.word irq_vektor_usart2tx+1  @  USART2_TX_IRQHandler   ; 15: USART2_TX Interrupt
.word irq_vektor_uart0rx+1   @  UART0_RX_IRQHandler    ; 16: UART0_RX Interrupt
.word irq_vektor_uart0tx+1   @  UART0_TX_IRQHandler    ; 17: UART0_TX Interrupt
.word irq_vektor_leuart0+1   @  LEUART0_IRQHandler     ; 18: LEUART0 Interrupt
.word irq_vektor_leuart1+1   @  LEUART1_IRQHandler     ; 19: LEUART1 Interrupt
.word irq_vektor_letimer0+1  @  LETIMER0_IRQHandler    ; 20: LETIMER0 Interrupt
.word irq_vektor_pcnt0+1     @  PCNT0_IRQHandler       ; 21: PCNT0 Interrupt
.word irq_vektor_pcnt1+1     @  PCNT1_IRQHandler       ; 22: PCNT1 Interrupt
.word irq_vektor_pcnt2+1     @  PCNT2_IRQHandler       ; 23: PCNT2 Interrupt
.word irq_vektor_rtc+1       @  RTC_IRQHandler         ; 24: RTC Interrupt
.word irq_vektor_cmu+1       @  CMU_IRQHandler         ; 25: CMU Interrupt
.word irq_vektor_vcmp+1      @  VCMP_IRQHandler        ; 26: VCMP Interrupt
.word irq_vektor_lcd+1       @  LCD_IRQHandler         ; 27: LCD Interrupt
.word irq_vektor_msc+1       @  MSC_IRQHandler         ; 28: MSC Interrupt
.word irq_vektor_aes+1       @  AES_IRQHandler         ; 29: AES Interrupt 

@ -----------------------------------------------------------------------------
