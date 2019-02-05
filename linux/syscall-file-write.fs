\ write file via syscall interface                      uh 2015-09-26

\ : syscall ( r0 r1 r2 r3 r4 r5 r6 Syscall# -- r0 )

\ int creat(const char *pathname, mode_t mode);
8 constant #creat

8 base ! 
00444 constant S_IRUSR
00222 constant S_IWUSR
00111 constant S_IXUSR
decimal

: 0terminate ( addr len -- ) + 0 swap c! ;

: syscall-creat ( addr len mode -- fd )
  >r  dup >r here swap move  here r> 0terminate 
  here r> 0 0 0 0 0 #creat syscall ;


\ ssize_t write(int fd, const void *buf, size_t count);
4 constant #write
: syscall-write ( adr len fd -- len' )  -rot 0 0 0 0 #write syscall ; 

\ int close(int fd)
6 constant #close
: syscall-close ( fd -- ior ) 0 0 0 0 0 0 #close syscall ;

\ example: write logfile

0 variable logfile
: open-log ( addr len -- )  
   S_IRUSR S_IWUSR or syscall-creat  logfile ! ;

: write-log ( addr len -- )
   logfile @ syscall-write drop ; 

create newline 10 c,

: writeln-log ( addr len )
   write-log
   newline 1 write-log ;

: close-log ( -- )  logfile @ syscall-close drop ;

: test
   s" logfile" open-log  
   s" line one" writeln-log 
   s" line two" writeln-log 
   close-log ;

