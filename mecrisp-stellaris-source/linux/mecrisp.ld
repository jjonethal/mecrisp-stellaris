ENTRY (_start)        /* Einsprungpunkt            */

SECTIONS {           /* lege Speicherinhalt fest          */

 . = 0x10000;
  
  mecrisp : {
    *(mecrisp);    /* Daten */
    *(.text);     /* Text (falls jemand .section mecrisp vergessen hat) */
    *(.data);    /* Daten (dito) */
  }

  userdictionary (NOLOAD) : {
    *(.bss);    /* Nullen */
  }

}
