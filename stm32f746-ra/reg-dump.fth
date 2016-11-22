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
\ 2016nov22jjo rename token -> name, fix >cfa alignment 16 bit
\              add some docs
\ 2016nov13jjo initial version

\ helper utility for dumping all the registers with their bit fields
\ word list structure: |link|flags|cname|pad?|code
\ word list entry consists of
\ * link  field - 4 bytes
\ * flags field - 2 bytes
\ * name  field - 2 .. 256 byte
\ * pad   field - 0 or 1 byte to fill gap to next even address for code
\ * code  field - 0 .. x byte could be up to 4 gb size usually much smaller 
\
\  ' XXX_REG 6 dump-reg         dump the register with 6 following constants as
\                               bit field definitions


\ require util.fth

$20000000 constant RAM-START             \ in RAM dictionary is backlinked

: align2 ( a -- a )                      \ align do 16 bit address
   1+ -2 and 1-foldable ;
: >name ( a -- a )                       \ retrieve name address for cfa
   1- dup c@ 0= +                        \ skip the padding zero
   #256 1 do 1- dup c@ i = if leave then loop ; \ backtrack to start of counted string
: cfa>link ( a -- a )                    \ find link address from cfa
   >name 6 - 1-foldable ;
: >cfa ( a -- a )                        \ calculate code start from link address
   6 + dup c@ 1+ + align2 1-foldable ;   \ 4 byte link 2 byte flags + strlen(+1) align 16bit
: link>name ( a -- a )                   \ calculate name adr from link adr
   6 + 1-foldable ;
: back-search-complete? ( ap ac -- f f ) \ f match f search finished
   dictionarynext if = -1 else = dup then ;
: dictionaryback ( a -- a f )            \ search dictionary back for words in
   dictionarystart                       \ RAM dictionary
   begin 2dup back-search-complete?
    if rot drop 0= -1                    \ finished search fix flag leave loop
    else drop dictionarynext             \ back link not found yet get next link
    then
   until ;
: last-entry ( -- a )                    \ scan to last entry of dictionary
   dictionarystart begin dictionarynext until ;
: words-reverse ( -- )                   \ dump words reverse
   last-entry begin dup 6 + ctype space dictionaryback until drop ;
: .name ( a -- )                         \ print name of link address
   link>name ctype ;
: get-bits ( v m -- v )                  \ retrieve bits from value with mask
   tuck and swap cnt0 rshift 2-foldable ;   
: name# ( l -- n )                       \ return length of name
   link>name c@ 1-foldable ;
: .name-fill ( l n -- )                  \ print name with fixed length fill BL
   over .name swap name# - spaces ; 
: dump-field ( v l -- )                  \ dump field by constant dict entry
   dup #32 .name-fill SPACE >cfa
   execute get-bits u.8 ; 
: next-link ( l -- l f )                 \ get next link, in RAM search backwards
    dup RAM-START >=
    if  dictionaryback
    else dictionarynext
    then ;
: dump-fields ( v l cnt -- )             \ dump value using number of consecutive
   0 do 2dup space dump-field cr         \ constant words dictionary entries
   next-link
   if leave then loop 2drop ;            \ exit and clean

\ ***************************************
\ dump the register contents as bit fields
\ it uses a number of n constants following the address constant for dump
\ of bit field 
\ example:
\   $12345 constant ABC_REG
\   $3 #20 lshift constant ABC_BF_20_2   
\   $1 #19 lshift constant ABC_BF_19_1 
\   $f #15 lshift constant ABC_BF_15_4
\   ' ABC_REG 3 dump-reg
: dump-reg ( cfa n -- )                  \ dump register by cfa and field count
   swap dup execute @ swap               \ retrieve register value
   cfa>link cr                           \ get dictionary entry
   2dup #34 .name-fill u.8 cr            \ print out register name
   next-link not                         \ get first bitfield definition
   if rot dump-fields                    \ if there are more fields dump them
   else 2drop drop                       \ no more fields found clean up
   then ;
