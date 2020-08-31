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

@ Schreiben und Löschen des Flash-Speichers im STM32wb55.

@ this chip has ecc flash memory protection and supports 64 bit writes
@ as 2 consecutive word accesses to one 64 bit area only

@ Write and Erase Flash in STM32wb55.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!

@ for stm32wb55 we will never introduce 8 byte mode

hexflashstore_fehler:
	Fehler_Quit "Flash cannot be written twice"

@ -----------------------------------------------------------------------------
	Wortbirne Flag_visible, "16flash!" @ Writes 16 Bytes at once into Flash.
hexflashstore: @ ( x1 x2 x3 x4 addr -- ) x1 contains LSB of those 128 bits.
@ -----------------------------------------------------------------------------
	push	{r0, r1, r2, r3, r4, r5, lr}
	@ Check if this goes into core - don't allow that ! No need to check for because of the second check.
	@ Perform write only if desired destination is in erased state...

	ldr	r0, =15
	ands	r0, tos
	beq	1f
	Fehler_Quit "16flash! needs 16-aligned address"

1:	ldr	r0, [tos] 			@ tos contains address to write
	adds	r0, r0, #1			@ quick check if memory contains $ffffffff
	bne 	hexflashstore_fehler

	ldr	r0, [tos, #4]			@ check next 4 bytes at offset 4
	adds	r0, r0, #1
	bne	hexflashstore_fehler

	ldr	r0, [tos, #8]			@ check empty at offset 8 - for stm32wb55
	adds	r0, r0, #1
	bne	hexflashstore_fehler

	ldr	r0, [tos, #12]
	adds	r0, r0, #1
	bne	hexflashstore_fehler

	@ Okay, alle Proben bestanden.

	@ Im STM32wb55 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
	@ Flash memory is mirrored, use true address later for write
@	ldr	r2, =0x08000000
@	adds	tos, r2

	@ Bereit zum Schreiben !

	@ Unlock Flash Control
	ldr	r2, =Flash_KEYR
	ldr	r3, =0x45670123
	str	r3, [r2]
	ldr	r3, =0xCDEF89AB
	str 	r3, [r2]

	@ erase previous errors
	ldr	r2, =Flash_SR
	ldr	r3, =1<<Flash_OPERR_Shift+1<<Flash_PROGERR_Shift+1<<Flash_WRPERR_Shift+1<<Flash_PGAERR_Shift+1<<Flash_SIZERR_Shift+1<<Flash_PGSERR_Shift+1<<Flash_MISERR_Shift+1<<Flash_FASTERR_Shift+1<<Flash_RDERR_Shift+1<<Flash_OPTVERR_Shift
	str	r3, [r2]

	@ Enable write
	ldr	r2, =Flash_CR
	ldr	r3, =1<<Flash_PG_Shift+1<<Flash_EOPIE_Shift		@ Select Flash programming
	str	r3, [r2]


	ldmia	psp!, {r3}			@ Fetch data to be written
	ldmia	psp!, {r2}
	ldmia	psp!, {r1}
	ldmia	psp!, {r0}

	stmia	tos!, {r0}
	stmia	tos!, {r1}

	@ Wait for Flash BUSY Flag to be cleared
	bl	waitflashopcomplete

	stmia	tos!, {r2}			@ program next 2 words
	stmia	tos!, {r3}
	@ wait again for flash op complete
	bl	waitflashopcomplete

	@ turn off programming mode
	ldr	r2, =Flash_CR
	ldr	r0, [r2]
	ldr	r1, =1<<Flash_PG_Shift
	bics	r0, r0, r1
	str	r0, [r2]

	@ lock flash again
	ldr	r2, =Flash_CR
	ldr	r0, [r2]
	ldr	r1, =1<<Flash_LOCK_Shift
	orrs	r0, r0, r1
	str	r0, [r2]

	drop					@ Forget destination address
	pop	{r0, r1, r2, r3, r4, r5, pc}

.ltorg

waitflashopcomplete:
	push	{r0, r1, r2}
  	ldr	r2, =Flash_SR
	ldr	r1, =1<<Flash_BSY_Shift
1:	ldr	r0, [r2]
	tst	r0, r1
	bne	1b				@ Wait for Flash BUSY Flag to be cleared
	ldr	r1, =1<<Flash_EOP_Shift
2:	ldr	r0, [r2]
	tst	r0, r1
	beq	2b				@ Wait for EOP Flag to be Set
	bics	r0, r0, r1
	str	r0, [r2]			@ clear EOP
	pop	{r0, r1, r2}
	bx	LR


@ -----------------------------------------------------------------------------
	Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
	@ Löscht einen 4 KiB großen Flashblock  Deletes one 4 KiB Flash page
flashpageerase:
@ -----------------------------------------------------------------------------
	push	{r0, r1, r2, r3, lr}
	popda	r0				@ Adresse zum Löschen holen Fetch address to erase.

	@ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ? Don't erase Forth core.
	ldr	r3, =Kernschutzadresse
	cmp	r0, r3
	blo	2f

	@ Flash key register
	ldr	r2, =Flash_KEYR
	ldr	r3, =0x45670123
	str	r3, [r2]
	ldr	r3, =0xCDEF89AB
	str	r3, [r2]

	@ STM32WB55 has 4 KiB pages and 1 MiB Flash, but only one bank -> 256 pages, 8 bits
	@ page size 4096 byte, 12 bits

	@ Set page to erase
	ldr	r1, =12				@ page size 12 bits
	lsrs	r0, r0, r1			@ shift down page size
	ldr	r1, =0xFF			@ bitWidth 8
	ands	r0, r0, r1			@ mask page number
	ldr	r1, =Flash_PNB_Shift
	lsls	r0, r0, r1			@ Page number selection
	ldr	r1, =1<<Flash_PER_Shift 	@ Set Page erase
	orrs	r0, r0, r1
	ldr	r2, =Flash_CR
	str	r0, [r2]

	@ start erasing
	ldr	r1, =1<<Flash_STRT_Shift	@ Set start bit
	orrs	r0, r0, r1
	str	r0, [r2]			@ erase page

	@ Wait for Flash BUSY Flag to be cleared
	ldr	r2, =Flash_SR
1:    	ldr	r3, [r2]
	ldr	r0, =1<<Flash_BSY_Shift
	ands	r0, r0, r3
	bne	1b

	@ Lock Flash after finishing this
	ldr	r2, =Flash_CR
	ldr	r0, [r2]
	ldr	r1, =1<<Flash_LOCK_Shift
	orrs	r0, r0, r1
	str	r0, [r2]

	@ clear cache
	@ save old cache settings
	ldr	r2, =Flash_ACR
	ldr	r1, [r2]
	push	{r1}

	@ turn cache off
	ldr	r0, =(1<<Flash_ICEN_Shift) | (1<<Flash_DCEN_Shift)
	bics	r1, r1, r0
	str	r1, [r2]

	@ reset cache
	ldr	r0, =(1<<Flash_ICRST_Shift) | (1<<Flash_DCRST_Shift)
	orrs	r1, r1, r0
	str	r1, [r2]

	@ restore flash settings
	pop	{r1}
	str	r1, [r2]

2:	pop	{r0, r1, r2, r3, pc}

.ltorg

@ -----------------------------------------------------------------------------
	Wortbirne Flag_visible, "eraseflash" @ ( -- )
	@ Löscht den gesamten Inhalt des Flashdictionaries.
@ -----------------------------------------------------------------------------
        ldr	r0, =FlashDictionaryAnfang
eraseflash_intern:
	cpsid	i
	ldr	r1, =FlashDictionaryEnde
	ldr	r2, =0xFFFF

1:      ldrh	r3, [r0]
	cmp	r3, r2
	beq	2f
	pushda	r0
	dup
	write	"Erase block at  "
	bl	hexdot
	writeln " from Flash"
	bl	flashpageerase
2:      adds	r0, r0, #2
	cmp	r0, r1
	bne	1b
	writeln	"Finished. Reset !"
	bl	Restart

@ -----------------------------------------------------------------------------
	Wortbirne Flag_visible, "eraseflashfrom" @ ( Addr -- )
	@ Beginnt an der angegebenen Adresse mit dem Löschen des Dictionaries.
@ -----------------------------------------------------------------------------
	popda	r0
	b.n	eraseflash_intern
.ltorg
