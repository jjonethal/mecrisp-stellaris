@ rp2350 image identificator block
@ borrowed from rp2350 data sheet 5.9.5.1. Minimum Arm IMAGE_DEF
@ https://datasheets.raspberrypi.com/rp2350/rp2350-datasheet.pdf

@ ---- IMAGE_DEF --------------------------------------------------------------
@ must be located within the first 4 kByte
.word 0xffffded3 @ PICOBIN_BLOCK_MARKER_START
.word 0x10210142
.word 0x000001ff
.word 0x00000000
.word 0xab123579