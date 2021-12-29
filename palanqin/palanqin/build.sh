set -ev
nasm -l palanqin.lst -g -f elf32 palanqin.asm
ld -T com.ld -m elf_i386 -o palanqin.elf palanqin.o
objcopy -O binary palanqin.elf palanqin.com
