ENTRY (_start)                 /* Einsprungpunkt            */

SECTIONS {                     /* lege Speicherinhalt fest          */

  . = 0x10000;
  incipit = .;                 /* Jedem Anfang wohnt ein Zauber inne */
  
  mecrisp : {
    *(elfheader);              /* ELF header */
    . = ALIGN(4);              /* ensure alignment */
    mecrispoffset = . - incipit; /* where data begins in the file */
    *(mecrisp);                /* Daten */
    *(.text);                  /* Text (falls jemand .section mecrisp vergessen hat) */
    *(.data);                  /* Daten (dito) */
    . = ALIGN(4096);           /* align to next page (for memory protection) */
    kernsize = . - incipit;    /* Forth kernel size */

  }
  userdictionary (NOLOAD) : {
    userdictionaryoffset = . - incipit; /* where userdictionary begins in the file */
    *(.bss);                   /* Nullen */
  }

  explicit = .;                 /* Aus und vorbei! */
}
