: require  ( word )    \ check if word is in dictionary otherwise send "include word" to terminal 
   >in @               \ backup source pointer 
   token 2dup          \ we might type it later
   find                \ find string in dictionary
   drop 0=             \ flags not needed
   if                  \ word is not yet in dictionary 
     rot >in !         \ restore source pointer
     create            \ and create the word in dictionary
     ." include " type \ send include message to terminal
   else
     drop 2drop        \ already in dictionary clean up stack
   then ;
