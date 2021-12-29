
MEMORY
{
   rom(RX)   : ORIGIN = 0x00000000, LENGTH = 0x10000
   ram(WAIL) : ORIGIN = 0x20000000, LENGTH = 0x2000
}

SECTIONS
{
   .text : { *(.text*) } > rom
   .bss  : { *(.bss*) } > ram
}

