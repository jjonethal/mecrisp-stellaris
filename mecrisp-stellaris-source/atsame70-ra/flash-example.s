
		//now do some flash init.
		//clear the page  buffer and write 
		//all FFFFFFFF's to a page
		//this way the page buffer will be 
		//in a all one state after programming (this is not the case at 
		//reset or power-on condition !)

/*
		ldr	r0,=0x00407000
		add	r2,r0,#0x200
		ldr	r1,=0xffffffff
clearflash_buf:	str	r1,[r0],#+4
		cmp	r0,r2
		bne	clearflash_buf
		//now program the 'empty' buffer to
		//0x407000-0x407200 which equals page nr 56
		ldr	r0,=EEFC_FCR
		ldr	r1,=0x5a003801
		str	r1,[r0]
		bl	waitflrdy
		
		//flash page buffer is now in a erased state !		

		//test partial write
		
		
		ldr	r0,=0x00408000
		ldr	r1,=0x01234567
		str	r1,[r0],#+4
		ldr	r1,=0x89abcdef
		str	r1,[r0],#+4
		ldr	r1,=0x55aa55aa
		str	r1,[r0],#+4
		ldr	r1,=0x00ff00ff
		str	r1,[r0],#+4

		//now program the 16 bytes in the buffer to
		//0x408000h equals page nr 64
		ldr	r0,=EEFC_FCR
		ldr	r1,=0x5a004001
		str	r1,[r0]
		bl	waitflrdy
		

		ldr	r0,=0x00408010
		ldr	r1,=0xabbaabba
		str	r1,[r0],#+4
		ldr	r1,=0xdeadbeef
		str	r1,[r0],#+4
		ldr	r1,=0xbeefdead
		str	r1,[r0],#+4
		ldr	r1,=0x00000000
		str	r1,[r0],#+4

		//now program the 16 bytes in the buffer to
		//0x408000h equals page nr 64
		ldr	r0,=EEFC_FCR
		ldr	r1,=0x5a004001
		str	r1,[r0]
		bl	waitflrdy
		
		
		ldr	r0,=0x0040820
		ldr	r1,=0x33333333
		str	r1,[r0],#+4
		ldr	r1,=0x55555555
		str	r1,[r0],#+4
		ldr	r1,=0x77777777
		str	r1,[r0],#+4
		ldr	r1,=0x99999999
		str	r1,[r0],#+4

		//now program the 16 bytes in the buffer to
		//0x408000h equals page nr 64
		ldr	r0,=EEFC_FCR
		ldr	r1,=0x5a004001
		str	r1,[r0]
		bl	waitflrdy
		
		ldr	r0,=0x0040830
		ldr	r1,=0x11111111
		str	r1,[r0],#+4
		ldr	r1,=0x22222222
		str	r1,[r0],#+4
		ldr	r1,=0x44444444
		str	r1,[r0],#+4
		ldr	r1,=0x88888888
		str	r1,[r0],#+4

		//now program the 16 bytes in the buffer to
		//0x408000h equals page nr 64
		ldr	r0,=EEFC_FCR
		ldr	r1,=0x5a004001
		str	r1,[r0]
		bl	waitflrdy		



		bx	lr


waitflrdy:	//wait for not busy flag
		push	{lr}
waitflrdy2:	ldr	r0,=EEFC_FSR
		ldr	r1,[r0]
		tst	r1,#1
		beq	waitflrdy2
		pop	{pc}

*/
