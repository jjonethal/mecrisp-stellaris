\ Constants for GPIO Ports A-E

$400FF000 constant GPIOA_PDOR   \ Port Data Output Register
$400FF004 constant GPIOA_PSOR   \ Port Set Output Register
$400FF008 constant GPIOA_PCOR   \ Port Clear Output Register
$400FF00C constant GPIOA_PTOR   \ Port Toggle Output Register
$400FF010 constant GPIOA_PDIR   \ Port Data Input Register
$400FF014 constant GPIOA_PDDR   \ Port Data Direction Register

$400FF040 constant GPIOB_PDOR   \ Port Data Output Register
$400FF044 constant GPIOB_PSOR   \ Port Set Output Register
$400FF048 constant GPIOB_PCOR   \ Port Clear Output Register
$400FF04C constant GPIOB_PTOR   \ Port Toggle Output Register
$400FF050 constant GPIOB_PDIR   \ Port Data Input Register
$400FF054 constant GPIOB_PDDR   \ Port Data Direction Register

$400FF080 constant GPIOC_PDOR   \ Port Data Output Register
$400FF084 constant GPIOC_PSOR   \ Port Set Output Register
$400FF088 constant GPIOC_PCOR   \ Port Clear Output Register
$400FF08C constant GPIOC_PTOR   \ Port Toggle Output Register
$400FF090 constant GPIOC_PDIR   \ Port Data Input Register
$400FF094 constant GPIOC_PDDR   \ Port Data Direction Register

$400FF0C0 constant GPIOD_PDOR   \ Port Data Output Register
$400FF0C4 constant GPIOD_PSOR   \ Port Set Output Register
$400FF0C8 constant GPIOD_PCOR   \ Port Clear Output Register
$400FF0CC constant GPIOD_PTOR   \ Port Toggle Output Register
$400FF0D0 constant GPIOD_PDIR   \ Port Data Input Register
$400FF0D4 constant GPIOD_PDDR   \ Port Data Direction Register

$400FF100 constant GPIOE_PDOR   \ Port Data Output Register
$400FF104 constant GPIOE_PSOR   \ Port Set Output Register
$400FF108 constant GPIOE_PCOR   \ Port Clear Output Register
$400FF10C constant GPIOE_PTOR   \ Port Toggle Output Register
$400FF110 constant GPIOE_PDIR   \ Port Data Input Register
$400FF114 constant GPIOE_PDDR   \ Port Data Direction Register

$40049000 constant PORTA_PCR \ For Pin 0. Add n*4 for the other pins !
$40049080 constant PORTA_GPCLR
$40049084 constant PORTA_GPCHR

$4004A000 constant PORTB_PCR
$4004A080 constant PORTB_GPCLR
$4004A084 constant PORTB_GPCHR

$4004B000 constant PORTC_PCR
$4004B080 constant PORTC_GPCLR
$4004B084 constant PORTC_GPCHR

$4004C000 constant PORTD_PCR
$4004C080 constant PORTD_GPCLR
$4004C084 constant PORTD_GPCHR

$4004D000 constant PORTE_PCR
$4004D080 constant PORTE_GPCLR
$4004D084 constant PORTE_GPCHR

