	.section mecrisp, "awx"				# alles im Forth-Abschnitt ist schreib und ausführbar
	.align 4
durchgaenge:
	.int 0						# eine Variable


	# ELF-Header
	# http://www.sco.com/developers/gabi/latest/ch4.eheader.html
elfhdr:	.byte 0x7f,'E','L','F'				# magische Zahl
	.byte 1						# ELF-Klasse: 32 Bit
	.byte 1						# Byte-Reihenfolge: little endian
	.byte 1						# ELF-Version: 1
	.byte 3						# ABI: GNU Linux
	.byte 0						# ABI-Version: 0
	.space 7					# 8 Padding Bytes
	.short 2					# ELF-Typ: ausführbare Datei
	.short 3					# Architektur: 80386 (für ARM: 40)
	.int 1						# ELF-Version: 1 (nochmal)
	.int _start					# Einsprungpunkt
	.int phdr-elfhdr				# Anfang des Programm-Headers in der Datei
	.int 0						# Anfang des Section-Headers (haben wir nicht)
	.int 0						# Flags: 0 (keine)
	.short elfhdr_len				# Größe des ELF-Headers: 56 Bytes
	.short 32					# Größe eines Programm-Headers: 32 Bytes
	.short 1					# Anzahl der Programm-Header: 1
	.short 40					# Größe eines Sektions-Headers: 40 Bytes
	.short 0					# Anzahl der Sektions-Header: 0 (keine)
	.short 0					# Offset der Sektions-String-Tafel (keine)
	.set elfhdr_len, .-elfhdr			# Länge des ELF-Headers

	# Programm-Header
	# Das Segment muss in der Datei genauso ausgerichtet sein
	# wie im Arbeitsspeicher, deshalb ist eine kleine Lücke zwischen
	# Headern und Speicherabzug.  Die Mindestausrichtung ist 4096,
	# also eine Speicherseite.  Alles darunter funktioniert leider nicht.
phdr:	.int 1						# Segment-Typ: LOAD
	.int 4096					# Anfang des Segments in der Datei
	.int anfang					# Adresse, zu der der Header geladen wird
	.int anfang					# physikalische Adresse (egal)
	.int groesse					# Länge des Segmentes in der Datei
	.int groesse					# Länge des Segmentes im Speicher
	.int 7						# Flags: RWX (lesen, schreiben, ausführen)
	.int 4096					# Ausrichtung des Segments: 4096 (eine Speicherseite)
	.set phdr_len, .-phdr				# Länge des Programm-Headers

benutzung:
	.string "Benutzung: "
dateiname:
	.ascii " <Dateiname>"
lf:	.string "\n"

kann_nicht_oeffnen:
	.string ": kann Datei nicht oeffnen\n"

durchgang:
	.string "Durchgang: "

	.globl _start
_start:	xor %ebp, %ebp
	cld
	pop %ecx					# argc (Anzahl der Argumente)
	mov %esp, %esi					# argv (Argumentliste)

	cmp $2, %ecx					# haben wir genau ein Argument?
	je 0f

	push $benutzung					# wenn nicht, gebe Nutzungshinweis aus
	call print
	push (%esi)
	call print
	push $dateiname
	call print
	push $1						# und beende das Programm
	call exit

0:	sub $8, %esp					# Platz auf dem Stapel machen
	mov %esp, %edi					# edi: Puffer für Zahl
	push %edi
	push durchgaenge
	call itox					# Zahl umwandeln

	push $durchgang
	call print
	push %edi
	call print
	push $lf
	call print
	add $56, %esp

	incl durchgaenge				# Zähle Durchgänge hoch
	push $0777					# Zugriffsrechte: rwxrwxrwx
	push $01101					# Modus: O_TRUNC|O_CREAT|O_WRONLY
							# (Datei anlegen, leeren, nur schreiben)
	push 4(%esi)					# Dateiname: argv[1]
	call open					# Öffne Datei
	add $12,%esp					# Argumente vom Stapel nehmen
	mov %eax, %edi					# edi = Dateinummer
	cmp $0, %edi
	jge 0f						# Erfolg?

	push 4(%esi)					# Fehlermeldung
	call print
	push $kann_nicht_oeffnen
	call print
	push $1
	call exit

0:	push $elfhdr_len+phdr_len
	push $elfhdr
	push %edi
	call write					# Header schreiben

	push $0						# SEEK_SET
	push $4096
	push %edi
	call lseek					# auf Position 4096 spulen

	push $groesse
	push $anfang
	push %edi
	call write					# Speicher abziehen

	push %edi
	call close					# Datei schließen
	add $32, %esp					# Stapel balancieren

	push $0
	call exit

	# nützliche Funktionen
	# write(dateinummer, puffer, länge)
write:	push %ebx
	mov $4, %eax
	mov 8(%esp), %ebx
	mov 12(%esp), %ecx
	mov 16(%esp), %edx
	int $0x80
	pop %ebx
	ret

	# open(dateiname, flags, zugriffsrechte)
open:	push %ebx
	mov $5, %eax
	mov 8(%esp), %ebx
	mov 12(%esp), %ecx
	mov 16(%esp), %edx
	int $0x80
	pop %ebx
	ret

	# close(dateinummer)
close:	push %ebx
	mov $6, %eax
	mov 8(%esp), %ebx
	int $0x80
	pop %ebx
	ret

	# lseek(dateinummer, abstand, woher)
lseek:	push %ebx
	mov $19, %eax
	mov 8(%esp), %ebx
	mov 12(%esp), %ecx
	mov 16(%esp), %edx
	int $0x80
	pop %ebx
	ret

	# exit(status)
exit:	mov $1, %eax
	mov 4(%esp), %ebx
	int $0x80
	ud2						# Absturz, falls ich was falsch gemacht habe

	# strlen(string)
strlen:	push %edi
	mov 8(%esp), %edi
	mov $-1, %ecx
	xor %al, %al
	repne scasb
	sub 8(%esp), %edi
	lea -1(%edi), %eax
	pop %edi
	ret

	# itox(nummer, puffer)
	# konvertiert Zahl achtstellig nach hexadezimal
hextab:	.ascii "0123456789abcdef"

itox:	push %edi
	mov 8(%esp), %edx				# Nummer
	mov 12(%esp), %edi				# Puffer
	mov $8, %ecx					# Zähler	
0:	xor %eax, %eax
	shld $4, %edx, %eax
	shl $4, %edx
	mov hextab(%eax), %al
	stosb
	dec %ecx
	jnz 0b
	xor %al, %al					# NULL-Terminator
	stosb
	pop %edi
	ret

	# print(string)
	# gibt C-String aus
print:	push 4(%esp)
	call strlen
	mov %eax, (%esp)
	push 8(%esp)
	push $1
	call write
	add $12, %esp
	ret
