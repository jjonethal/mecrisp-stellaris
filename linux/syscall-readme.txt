Using syscall with mecrisp/linux                                  uh 2015-09-26

On Linux mecrisp now has an interface to the linux kernel
via the syscall interface.

This allows to use operation system functionality from
within mecrisp.

The syscall interface is exposed via the syscall word:

 syscall ( r0 r1 r2 r3 r4 r5 r6 Syscall# -- r0 )

where Syscall# is the appropriate number of the syscall and 
r0 to r6 are parameters to the specific system call (0 when
not needed).

Syscall# numbers can be found in Linux/arch/arm/kernel/calls.S 
For example sys_read has the syscall number 4, sys_close has 6.

To learn about the parameters for each system call use the Linux
man system. System calls are documented in section 2 of the man
pages, e.g.  man 2 write  to see the explanations for the write system
call.

If a system call signals an error, then it typically returns an
error number. This is the negative of the number that the C runtime
library would store in the global variable errno. mecrisp does not
use errno but works on the error numbers that the system calls return.

For example syscall-close returns -9 if passed an invalid file descriptor.
The errno error number EBADF (Bad file number) has the value 9.

Have a look at the files syscall-file-write.fs and syscall.txt for 
some basic usages.

