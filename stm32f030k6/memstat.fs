\ memstat.fs
\ For use with Mecrisp-Stellaris Forth by Matthias Koch
\ Used with a STM32F051 MCU
\ Author:  T.Porter <terry@tjporter.com.au> 2017
\ This Program:  prints out memory stats
\ Screenpic for a STM32F051 with 8MB ram and 64KB Flash running RA 2.3.9 with M0 core for STM32F051
\ ...........................................
\  free
\  free (bytes)
\  FLASH.. TOTAL: 65472 USED: 20704 FREE: 44768
\  RAM.... FREE: 7172
\ ...........................................
compiletoflash

: flashfree compiletoram? $10000 compiletoflash here - swap if compiletoram then ;
: ramfree compiletoram? not flashvar-here compiletoram here - swap if compiletoflash then ;
: free ." (bytes) " cr
." FLASH.. TOTAL: " $1FFFF7CC @ abs dup . ." USED: " flashfree dup >r - . ." FREE: " r> . cr ." RAM.... FREE: " ramfree .
\ cr depth ." Stack Depth: " . cr
cr cr ;

compiletoram

\ end memstat.fs

