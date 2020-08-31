ENTRY (_start)                 /* Einsprungpunkt            */

SECTIONS {                     /* lege Speicherinhalt fest          */

  . = 0x10000;
  incipit = .;                 /* Jedem Anfang wohnt ein Zauber inne */
  
  mecrisp : {
    *(elfheader);              /* ELF header */
    . = ALIGN(16);             /* ensure alignment */
    mecrispoffset = . - incipit; /* where data begins in the file */
    *(mecrisp);                /* Daten */
    *(.text);                  /* Text (falls jemand .section mecrisp vergessen hat) */
    *(.data);                  /* Daten (dito) */
  }

  datasize = . - incipit;        /* how long the initialised data segment is */

  . = ALIGN(16);               /* ensure alignment */

  userdictionary (NOLOAD) : {
    userdictionaryoffset = . - incipit; /* where userdictionary begins in the file */
    *(.bss);                   /* Nullen */
  }

  explicit = .;                 /* Aus und vorbei! */
  totalsize = explicit - incipit; /* number of bytes in the program */
}
