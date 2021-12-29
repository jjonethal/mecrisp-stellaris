\ The SVC and PENDSV are designed to work together to allow low latency context switching, but
\ the mechanism is a useful building block. This code allows multiple high priority interrupts
\ to split their handlers into a short lower half and a larger upper half.

\ These memory mapped registers are part of system control block.
$E000ED04 constant ICSR      \ Used to raise the PendSV exception
$E000ED1C constant SHPR2     \ Contains the SVCall exception priority. Byte addressable.
$E000ED20 constant SHPR3     \ Contains the PendSV exception priority. Byte addressable.
$F0       constant SV_PRIO   \ SVCall and PendSV must have the priority.
28 bit    constant PENDSVSET \ Bit mask raising the PendSV exception when written to ICSR

\ Multiplexing the PENDSV exception between multiple handlers should add as little
\ overhead as possible. To acomplish this the pending handlers are tracked
\ in a bitmap.
32 constant pendsv-size
0  variable pendsv-used
0  variable pendsv-pending
pendsv-size cells buffer: pendsv-handlers

\ Reverse bit order (not byte order)
\ : rbit ( x -- x' ) [ $f6a6fa96 , ] 1-foldable inline ; \ RBIT rTOS, rTOS

\ Clear and execute all pending handlers.
: isr-pendsv ( -- )
	\ Keep at it until there are no pending handlers
	\ Reading the pending bitmask on each iteration implements a priority scheduler.
	begin ( pending )
		pendsv-pending @ ?dup
	while
		\ Find the first pending handler
		\ "rbit clz" can be replaced by "clz 31 swap -"
		rbit clz cells ( first )
		\ Clear handler's pending flag before running it.
		\ The order is important because a higher priority interrupt could
		\ set the pending flag while its handler is running.
		\ Running the handler before clearing the pending flag would introduce a race condition.
		0 over 0 pendsv-pending >bit-band + ! ( first )
		\ Finally run the pending handler
		pendsv-handlers + @ execute
	repeat ;

\ Attempt to register a PENDSV handler.
\ The maximum number of registered handlers is limited to pendsv-size.
: pendsv-register ( xt -- index success? )
	pendsv-used @ dup pendsv-size u< if
		tuck cells pendsv-handlers + !
		dup 1+ pendsv-used !
		true
	else
		drop -1 false
	then ;

\ Set the SVCall exception handler and its priority.
\ SVCall and PendSV have to share the lowest priority in the system.
: init-svcall ( -- )
	SV_PRIO SHPR2 3 + c!
	['] execute irq-svcall ! ;

\ Perform a system call.
\ Instead taking a system call number from the system call instruction
\ the handler takes a execution token on the data stack.
\ This offers no security and maximum flexibilty.
: svc ( -- ) [ $DF00 h, ] inline ;

\ Set the PendSV exception handler its priority.
\ SVCall and PendSV have to share the lowest priority in the system.
: init-pendsv ( -- )
	pendsv-size 0 do ['] nop i cells pendsv-handlers + ! loop
	SV_PRIO SHPR3 2 + c!
	['] isr-pendsv irq-pendsv ! ;

\ Raise the PendSV exception.
: raise-pendsv ( -- ) PENDSVSET ICSR ! inline ;

\ Mark a handler multiplexed by PendSV as pending and raise the PendSV exception.
: pend ( index -- ) 1 swap cells 0 pendsv-pending >bit-band + ! raise-pendsv ;

: init ( -- ) init init-svcall init-pendsv ;

\ Make SVC and PendSV multiplexing available
init-svcall init-pendsv

: foo ." foo" ;
: bar ." bar" ;
: baz ." baz" ;
' foo pendsv-register drop constant foo-id
' bar pendsv-register drop constant bar-id
' baz pendsv-register drop constant baz-id

\ Set foo, bar and baz pending in reverse order.
\ They should execute in the order baz, bar, foo because the pendsv exception interrupts normal execution
: test1 ( -- ) baz-id pend bar-id pend foo-id pend ;

\ Set foo, bar, and baz pending in reverse order via svc.
\ This time they should execute in the order of their indices,
\ because the SVCall and PendSV exception have same priority using
\ the interrupt controller instead of fighting it
\ by masking/disabling interrupts in critical sections.
: test2 ( -- ) ['] test1 svc ;