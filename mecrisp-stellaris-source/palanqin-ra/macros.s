	.syntax unified
	.thumb

	.macro	palanqin_bye
	.inst.n	0xb700
	.endm

	.macro	palanqin_debug
	.inst.n	0xb701
	.endm

	.macro	palanqin_emit
	.inst.n	0xb702
	.endm

	.macro	palanqin_key
	.inst.n	0xb703
	.endm
