
: init ( -- )
  168mhz
  init-cycles
  init-rng
  ['] ct-irq irq-fault !
  usb-init ['] usb-poll hook-pause !
  +usb
;

cornerstone eraseflash
