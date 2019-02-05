@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@    Copyright (C) 2018  juju2013@github
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

.word irq_vektor_NVIC0+1
.word irq_vektor_NVIC1+1
.word irq_vektor_NVIC2+1
.word irq_vektor_NVIC3+1
.word irq_vektor_NVIC4+1
.word irq_vektor_NVIC5+1
.word irq_vektor_NVIC6+1
.word irq_vektor_NVIC7+1
.word irq_vektor_NVIC8+1
.word irq_vektor_NVIC9+1


.word irq_vektor_NVIC10+1
.word irq_vektor_NVIC11+1
.word irq_vektor_NVIC12+1
.word irq_vektor_NVIC13+1
.word irq_vektor_NVIC14+1
.word irq_vektor_NVIC15+1
.word irq_vektor_NVIC16+1
.word irq_vektor_NVIC17+1
.word irq_vektor_NVIC18+1
.word irq_vektor_NVIC19+1

.word irq_vektor_NVIC20+1
.word irq_vektor_NVIC21+1
.word irq_vektor_NVIC22+1
.word irq_vektor_NVIC23+1
.word irq_vektor_NVIC24+1
.word irq_vektor_NVIC25+1
.word irq_vektor_NVIC26+1
.word irq_vektor_NVIC27+1
.word irq_vektor_NVIC28+1
.word irq_vektor_NVIC29+1

.word irq_vektor_NVIC30+1
.word irq_vektor_NVIC31+1
.word irq_vektor_NVIC32+1
.word irq_vektor_NVIC33+1
.word irq_vektor_NVIC34+1
.word irq_vektor_NVIC35+1
.word irq_vektor_NVIC36+1
.word irq_vektor_NVIC37+1
.word irq_vektor_NVIC38+1

@ -----------------------------------------------------------------------------
