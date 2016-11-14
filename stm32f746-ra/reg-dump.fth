\ Copyright Jean Jonethal 2015, 2016
\
\ This program is free software: you can redistribute it and/or modify
\ it under the terms of the GNU General Public License as published by
\ the Free Software Foundation, either version 3 of the License, or
\ (at your option) any later version.
\
\ This program is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
\ GNU General Public License for more details.

\ You should have received a copy of the GNU General Public License
\ along with this program.  If not, see <http://www.gnu.org/licenses/>.

\ file reg-dump.fth
\ ********** history ********************
\ 2016nov13jjo initial version

\ helper utility for dumping all the registers with their bits
\ 
\

: >token ( a -- a )                      \ retrieve token name address for cfa
   1- dup c@ 0= +                        \ skip the padding zero
   #256 1 do 1- dup c@ i = if leave then loop ; \ backtrack to start of counted string
: cfa>link ( a -- a )                    \ find link address from cfa
   >token 6 - ;
: >cfa ( a -- a )                        \ calculate code start link address
   6 + dup c@ + 2 + 3 not and ;          \ 4 byte link 2 byte flags + strlen(+1) align 16bit
: link>token ( a -- a )
   6 + ;
: back-search-complete? ( ap ac -- f f ) \ f match f search finished
   dictionarynext if = -1 else = dup then ;

   
: dictionaryback ( a -- a f )            \ search dictionary back 
   dictionarystart
   begin 2dup back-search-complete?
    if rot drop 0= -1                    \ finished search fix flag leave loop
    else drop dictionarynext             \ back link not found yet get next link
    then
   until ;

: last-entry ( -- a )                    \ scan to last entry of dictionary
   dictionarystart begin dictionarynext until ;

: words-reverse ( -- )                   \ dump words reverse
   last-entry begin dup 6 + ctype space dictionaryback until drop ;

: .token ( a -- )                        \ print token of link address
   link>token ctype ;

: get-bits ( v m -- v )                  \ retrieve bits from value with mask
   tuck and swap cnt0 rshift 2-foldable ;   

: dump-field ( v l -- )                  \ dump field by constant dict entry
   dup .token ."  " >cfa execute get-bits u.8 ; 

: next-link ( l -- l f )                 \ get next link, in RAM search backwards
    dup $20000000 >=
    if  dictionaryback
    else dictionarynext
    then ;

: dump-fields ( v l cnt -- )             \ dump value using number of consecutive
   0 do 2dup dump-field next-link        \ constant words dictionary entries
   if leave then loop ;

: dump-reg-val ( v a n -- )  ;           \ dump a value with respect to cfa of
                                         \ constant definition 
                                         \ and number of field definitions
: dump-reg ( n cfa -- )                  \ dump register by cfa and field count
   dup execute @ swap                    \ retrieve register value
   cfa>link                              \ get dictionary entry
   dup .token cr                         \ print out register name
   next-link not                         \ get first bitfield definition
   if rot dump-fields
   else 2drop drop
   then ;
