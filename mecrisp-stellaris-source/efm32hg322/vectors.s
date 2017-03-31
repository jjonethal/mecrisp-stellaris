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

.word irq_vektor_dma+1       @    DMA_IRQn            = 0,  /*!< 16+0 EFM32 DMA Interrupt */
.word irq_vektor_gpioeven+1  @    GPIO_EVEN_IRQn      = 1,  /*!< 16+1 EFM32 GPIO_EVEN Interrupt */t
.word irq_vektor_timer0+1    @    TIMER0_IRQn         = 2,  /*!< 16+2 EFM32 TIMER0 Interrupt */
.word irq_vektor_acmp0+1     @    ACMP0_IRQn          = 3,  /*!< 16+3 EFM32 ACMP0 Interrupt */t
.word irq_vektor_adc0+1      @    ADC0_IRQn           = 4,  /*!< 16+4 EFM32 ADC0 Interrupt */t
.word irq_vektor_i2c0+1      @    I2C0_IRQn           = 5,  /*!< 16+5 EFM32 I2C0 Interrupt */
.word irq_vektor_gpioodd+1   @    GPIO_ODD_IRQn       = 6,  /*!< 16+6 EFM32 GPIO_ODD Interrupt */
.word irq_vektor_timer1+1    @    TIMER1_IRQn         = 7,  /*!< 16+7 EFM32 TIMER1 Interrupt */
.word irq_vektor_usart1rx+1  @    USART1_RX_IRQn      = 8,  /*!< 16+8 EFM32 USART1_RX Interrupt */
.word irq_vektor_usart1tx+1  @    USART1_TX_IRQn      = 9,  /*!< 16+9 EFM32 USART1_TX Interrupt */
.word irq_vektor_leuart0+1   @    LEUART0_IRQn        = 10, /*!< 16+10 EFM32 LEUART0 Interrupt */
.word irq_vektor_pcnt0+1     @    PCNT0_IRQn          = 11, /*!< 16+11 EFM32 PCNT0 Interrupt */
.word irq_vektor_rtc+1       @    RTC_IRQn            = 12, /*!< 16+12 EFM32 RTC Interrupt */pt
.word irq_vektor_cmu+1       @    CMU_IRQn            = 13, /*!< 16+13 EFM32 CMU Interrupt */pt
.word irq_vektor_vcmp+1      @    VCMP_IRQn           = 14, /*!< 16+14 EFM32 VCMP Interrupt */pt
.word irq_vektor_msc+1       @    MSC_IRQn            = 15, /*!< 16+15 EFM32 MSC Interrupt */pt
.word irq_vektor_aes+1       @    AES_IRQn            = 16, /*!< 16+16 EFM32 AES Interrupt */t
.word irq_vektor_usart0rx+1  @    USART0_RX_IRQn      = 17, /*!< 16+17 EFM32 USART0_RX Interrupt */t
.word irq_vektor_usart0tx+1  @    USART0_TX_IRQn      = 18, /*!< 16+18 EFM32 USART0_TX Interrupt */
.word irq_vektor_usb+1       @    USB_IRQn            = 19, /*!< 16+19 EFM32 USB Interrupt */
.word irq_vektor_timer2+1    @    TIMER2_IRQn         = 20, /*!< 16+20 EFM32 TIMER2 Interrupt */t

@ -----------------------------------------------------------------------------
