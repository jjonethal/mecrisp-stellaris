\ Save a copy of the current Forth core with all contents of the user flash

\ -----------------------------------------------------------------------------
\ useful system calls
\ -----------------------------------------------------------------------------

\ : syscall ( r0 r1 r2 r3 r4 r5 r6 Syscall# -- r0 )

\ int open(const char *pathname, int flags, mode_t mode);
5 constant #open

8 base ! 
00444 constant S_IRUSR
00222 constant S_IWUSR
00111 constant S_IXUSR
decimal

8 base !
00000 constant O_RDONLY \ open for reading only
00001 constant O_WRONLY \ open for writing only
00002 constant O_RDWR   \ open for reading and writing
02000 constant O_APPEND \ set append mode
00100 constant O_CREAT  \ create if nonexistent
01000 constant O_TRUNC  \ truncate to zero length
00200 constant O_EXCL   \ error if already exists
decimal

: 0terminate ( addr len -- ) + 0 swap c! ;

: syscall-creat ( addr len mode -- fd )
  >r  dup >r here swap move  here r> 0terminate 
  here O_WRONLY O_CREAT or O_TRUNC or r> 0 0 0 0 #open syscall ;

\ ssize_t write(int fd, const void *buf, size_t count);
4 constant #write
: syscall-write ( fd addr len -- len' ) 0 0 0 0 #write syscall ; 

\ int close(int fd)
6 constant #close
: syscall-close ( fd -- ior ) 0 0 0 0 0 0 #close syscall ;

\ -----------------------------------------------------------------------------
\ reading and writing ELF headers
\ -----------------------------------------------------------------------------

\ retrieve program headers
: elfhdr>phdrs ( elfhdr -- phdrs )
  dup $1c + @ + ;

\ update program header file size
: p_filesz! ( phdr filesz -- )
  swap $10 + ! ;

\ retrieve section headers
: elfhdr>shdrs ( elfhdr -- shdrs )
  dup $20 + @ + ;

\ retrieve section header size
: elfhdr>shentsize ( elfhdr -- entsize )
  $2e + h@ ;

\ retrieve the desired section header
: elfhdr>shdr ( elfhdr i -- shdr )
  >r dup elfhdr>shdrs swap elfhdr>shentsize r> * + ;

\ adjust section end
: sh_end! ( shdr end -- )
  over $0c + @ -         \ compute sh_size from sh_addr and end
  swap $14 + ! ;         \ update sh_size

\ adjust section base address in image and memory
: sh_addr! ( shdr addr -- )
  over $0c + @ - >r         \ compute adjustment
  r@ over $0c + +!          \ adjust sh_addr
  r@ over $10 + +!          \ adjust sh_offset
  $14 + r> negate swap +! ; \ adjust sh_size

\ ELF section numbers (see elfheader.s)
2 constant #mecrisp
3 constant #userdictionary

\ adjust our own ELF header according to here
: adjustelf ( -- )
  incipit elfhdr>phdrs here incipit - p_filesz!
  incipit #mecrisp elfhdr>shdr here sh_end!
  incipit #userdictionary elfhdr>shdr here sh_addr! ;

\ -----------------------------------------------------------------------------
\ saving the program image back to disk
\ -----------------------------------------------------------------------------

: save ( addr len -- ) \ Save a copy of the whole Forth core with flash dictionary contents

  compiletoram? compiletoflash >r

  adjustelf
  S_IRUSR S_IWUSR S_IXUSR or or syscall-creat \ open new program image
  dup incipit here incipit - syscall-write drop
  syscall-close drop

  r> if compiletoram then
;

: save" ( -- ) [char] " parse save ;

\ -----------------------------------------------------------------------------
