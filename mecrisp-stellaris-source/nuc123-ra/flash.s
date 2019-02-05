@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@    Copyright (C) 2017,2018  juju2013@github
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

@ Writing and erasing the flash memory in the NUC123.

@ Write and Erase Flash in NUC123.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!

    .equ CONFIG0    ,0x00300000  @ USER CONFIG0
    .equ CONFIG1    ,CONFIG0+4   @ USER CONFIG0
    .equ FMC_BA     ,0x5000C000  @ Base FMC address
    .equ ISPCON     ,FMC_BA+0x00 @ R/W ISP Control Register 0x0000_0000 
    .equ ISPADR     ,FMC_BA+0x04 @ R/W ISP Address Register 0x0000_0000 
    .equ ISPDAT     ,FMC_BA+0x08 @ R/W ISP Data Register 0x0000_0000 
    .equ ISPCMD     ,FMC_BA+0x0C @ R/W ISP Command Register 0x0000_0000 
    .equ ISPTRG     ,FMC_BA+0x10 @ R/W ISP Trigger Register 0x0000_0000 
    .equ DFBADR     ,FMC_BA+0x14 @ R Data Flash Start Address (DFVSEN = 1) 0x0001_F000 
    .equ DFBADR     ,FMC_BA+0x14 @ R Data Flash Start Address (DFVSEN = 0) CONFIG1 
    .equ FATCON     ,FMC_BA+0x18 @ R/W Flash Access Window Control Register 0x0000_0000 
    .equ ISPSTA     ,FMC_BA+0x40 @ R ISP Status Register 0x0000_0000

    .equ ISPCMD_ERASE   ,0x22    
    .equ ISPCMD_WRITE   ,0x21
    .equ ISPCMD_READ    ,0
    .equ ISPCMD_COMID   ,0x0b   @ Company ID
    .equ ISPCMD_UID     ,0x04   @ UNIQ ID    
    .equ ISPCMD_VMAP    ,0x2e   @ Vector map
    
    .equ PAGE_ADR_MASK  ,~(512-1)  @bitmask for page addressc

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hflash!" @ ( x Addr -- )
  @ Schreibt an die auf 2 gerade Adresse in den Flash.
  @ Write a halfword to the flash.
h_flashkomma:
@ -----------------------------------------------------------------------------
  push {lr}
  popda r0 @ Adresse
  popda r1 @ Inhalt / content

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  @ Is the desired location in the Flash Dictionary? Outside the Forth core?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 5f

  ldr r3, =FlashDictionaryEnde
  cmp r0, r3
  bhs 5f


  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  @ Check content. Only write if it is NOT -1.
  ldr r3, =0xFFFF
  ands r1, r3  @ High-Halfword der Daten wegmaskieren / Mask away high-halfword of the data
  cmp r1, r3
  beq 4f @ Fertig ohne zu Schreiben / Done without writing

  @ Prüfe die Adresse: Sie muss auf 2 gerade sein:
  @ Check the address: it needs to be divisible by 2:
  movs r2, #1
  ands r2, r0
  cmp r2, #0
  bne 5f

  @ Ist an der gewünschten Stelle -1 im Speicher ?
  @ Is 0xffff in memory at the desired location?
  ldrh r2, [r0]
  cmp r2, r3
  bne 5f

  @ Okay, alle Proben bestanden. / all samples passed 

  @ If low halfword assume high halfword =0xFFFF
  @ if high halfword reflash low halfword as well

  movs r3, #2
  ands r3, r0
  beq 1f @ low halfword
  eors r0, r3
  ldrh r3, [r0]
  lsls r1, #16
  orrs r1, r3
  b 2f 
1: ldr r3, =0xFFFF0000
   orrs r1, r3     
2: nop

  @ Enable write
  push {r0, r1}
  bl  sys_unlock
  bl  fmc_enable
  pop {r0, r1}
  
  @--- write data
  movs  r2, #ISPCMD_WRITE
  ldr   r3, =ISPCMD
  str   r2, [r3]
  
  ldr   r3, =ISPADR
  str   r0, [r3]
  
  ldr   r3, =ISPDAT
  str   r1, [r3]
  
  movs  r0, #0x01
  ldr   r3, =ISPTRG
  str   r0, [r3]

  @--- wait Flash operation finish
  isb  
3:ldr   r2, [r3]
  ands  r0, r0, r2
  bne   3b
  
  @ Lock Flash after finishing this
  bl  fmc_disable
  bl  sys_lock

4:pop {pc}
5:Fehler_Quit "Wrong address or data for writing flash !"


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- ) any address, will start at 512 boundery
  @ Deletes a 512 bytes Flash page
flashpageerase:
@ -----------------------------------------------------------------------------
  push    {lr}
  popda   r0 @ Adresse of page to erase

  @--- align to page
  ldr     r1, =PAGE_ADR_MASK
  ands    r0, r0, r1
  
  @ Enable write
  push {r0, r1}
  bl  sys_unlock
  bl  fmc_enable
  pop {r0, r1}

  @--- erase flash
  movs  r2, #ISPCMD_ERASE
  ldr   r3, =ISPCMD
  str   r2, [r3]
  
  ldr   r3, =ISPADR
  str   r0, [r3]
  
  movs  r0, #0x01
  ldr   r3, =ISPTRG
  str   r0, [r3]

  @--- wait Flash operation finish
  isb  
1:ldr   r2, [r3]
  ands  r0, r0, r2
  bne   1b
  
  @ Lock Flash after finishing this
  bl  fmc_disable
  bl  sys_lock

2:pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
  @ Löscht den gesamten Inhalt des Flashdictionaries.
  @ Clears the entire contents of the Flash dictionary.
@ -----------------------------------------------------------------------------
  ldr r0,   =FlashDictionaryAnfang
eraseflash_intern:
  cpsid     i
  ldr       r1, =FlashDictionaryEnde

1:ldr       r2, =0xFFFF
  ldrh      r3, [r0]
  cmp       r3, r2
  beq       2f
  pushda    r0
  dup
  write     "Erase block at  "
  bl        hexdot
  writeln   " from Flash"
  push      {r0, r1, r2, r3}
  bl        flashpageerase
  pop       {r0, r1, r2, r3}
2:movs      r2, #0b01
  lsls      r2, r2, #9
  adds      r0, r0, r2
  cmp       r0, r1
  bne       1b
  writeln   "Finished. Reset !"
  bl        Restart

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflashfrom" @ ( Addr -- )
  @ Beginnt an der angegebenen Adresse mit dem Löschen des Dictionaries.
@ -----------------------------------------------------------------------------
        popda r0
        b.n eraseflash_intern

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "sys-unlock" @ ( -- )
sys_unlock:  @ ( --  ) allow write to protected registers
@ -----------------------------------------------------------------------------
    @--- unlock register
    ldr     r0, =REGWRPROT
    ldr     r1, =0x59
    str     r1, [r0]
    ldr     r1, =0x16
    str     r1, [r0]
    ldr     r1, =0x88
    str     r1, [r0]

    bx      lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "sys-lock" @ ( -- )
sys_lock:  @ ( --  ) protec sys registers
@ -----------------------------------------------------------------------------

    @--- lock register
    movs    r1, #0
    ldr     r0, =REGWRPROT
    str     r1, [r0]

    bx      lr
  
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "fmc-enable" @ ( -- )
fmc_enable:  @ ( --  ) allow Flash Memory Controler operations
@ -----------------------------------------------------------------------------

    ldr     r1, =ISPCON
    movs    r0, #0b111001
    str     r0, [r1]

    bx      lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "fmc-disable" @ ( -- )
fmc_disable:  @ ( --  ) disable Flash Memory Controler operations
@ -----------------------------------------------------------------------------

    ldr     r1, =ISPCON
    movs    r0, #0
    str     r0, [r1]

    bx      lr
