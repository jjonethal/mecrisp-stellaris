# nrf52-forth-lib
Forth lib for nrf52832 MCU

This is a simple library in [Forth](http://mecrisp.sourceforge.net/) to drive modules and peripherals on a nRF52832 MCU.

The covered, totally or partially, modules and peripherals are:

 * io.fs
 
   * GPIO: Pin's Configuration
   * GPIOTE: Connect Task and Event
   * PPI: Programmable Peripheral Interconnect
   * EGU: Event Generator Unit
  
 * rng.fs: Random Number Generator
 * nvic.fs: Nested Vectored Interrupt Controller
 * timer.fs: Timer Unit
 * i2s.fs: i2s unit
 * ws2812.fs: ws2812, aka NeoPixel, driver using i2s
 * main.fs: ws2821 animation

## Copyright

Copyright (C) 2018 by juju2013@github, under BSD license (see LICENSE file), 
some files are from [Embello](https://github.com/jeelabs/embello) and are in public domain
