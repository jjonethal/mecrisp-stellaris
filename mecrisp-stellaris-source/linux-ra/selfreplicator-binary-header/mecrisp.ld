ENTRY (_start)				/* Einsprungpunkt						*/
OUTPUT_FORMAT (binary)			/* Erzeuge Binärdatei ohne Header				*/
SECTIONS {				/* lege Speicherinhalt fest					*/
	. = 0x10000;			/* wir beginnen bei 64 kB
					   weniger geht auf vielen Linux-Systemen nicht			*/
	anfang = .;			/* definiert ein Symbol Anfang mit der aktuellen Adresse	*/

	elfheader : {
		*(elfheader);		/* ELF-Header							*/
	}

	mecrisp : {
		*(mecrisp);		/* Daten							*/
		*(.text);		/* Text (falls jemand .section mecrisp vergessen hat)		*/
		*(.data);		/* Daten (dito)							*/
		*(.bss);		/* Nullen							*/
	}
	ende = .;			/* Ende der Allokation						*/
	groesse = ende - anfang;	/* Groesse des Speicher-Segmentes				*/
}
