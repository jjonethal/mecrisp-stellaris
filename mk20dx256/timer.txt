\ Code for setting up the systick timer

$E000E010 constant NVIC_ST_CTRL_R
$E000E014 constant NVIC_ST_RELOAD_R
$E000E018 constant NVIC_ST_CURRENT_R


: systick-eint %111 NVIC_ST_CTRL_R ! ;
: systick-dint 0 NVIC_ST_CTRL_R ! ;
: systick-reset 0 NVIC_ST_CURRENT_R ! ;
: systick-reload-set ( ticks -- ) NVIC_ST_RELOAD_R ! ;

: systick-init ( ticks -- )
	systick-dint
	systick-reload-set
	systick-reset
	systick-eint eint
;

