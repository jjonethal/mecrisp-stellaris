set -e
as --32 -o elf_dumper.o elf_dumper.s
ld -T mecrisp.ld -m elf_i386 -o elf_dumper elf_dumper.o
# für FreeBSD: markiert Programm als Linux-Programm
# auf Linux ist das unnötig und wird ignoriert
brandelf -t Linux elf_dumper >/dev/null || true
