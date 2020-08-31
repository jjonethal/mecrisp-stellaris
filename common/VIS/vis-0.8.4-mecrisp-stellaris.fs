\   Filename: vis-0.8.4-mecrisp-stellaris.fs
\    Purpose: Adds VOCs, ITEMs and STICKY Words to Mecrisp-Stellaris
\        MCU: *
\      Board: * , tested with TI StellarisLaunchPad 
\       Core: Mecrisp-Stellaris by Matthias Koch.
\   Required: Mecrisp-Stellaris >= 0.27
\     Author: Manfred Mahlow          manfred.mahlow@forth-ev.de
\   Based on: vis-0.8.2-mecrisp-stellaris.txt
\    Licence: GPLv3
\  Changelog: 2020-05-22
\             Released as concatenation of the following files:
\             wordlists-0.8.4.fs , vis-0.8.4-core.fs , vis-0.8.4-??.fs
\             vis-0.8.2-also.fs ,  vis-0.8.2-vocs.fs . vis-0.8.3-items.fs
\ ----------------------------------------------------------------------------

\   Filename: wordlists-0.8.4.fs
\    Purpose: Adds WORDLISTs to Mecrisp-Stellaris RA
\        MCU: 
\      Board: * , tested with TI StellarisLaunchPad 
\       Core: Mecrisp-Stellaris by Matthias Koch.
\   Required: Mecrisp-Stellaris RA 2.3.8 or later
\     Author: Manfred Mahlow          manfred.mahlow@forth-ev.de
\   Based on: vocs-0.7.0
\    Licence: GPLv3
\  Changelog: 2020-04-19 wordlists-0.8.2.txt --> wordlists-0.8.3.fs
\             2020-05-20 smudge? changed
\             2020-05-22 wordlist changed  wid? added

\ Wordlists for Mecrisp-Stellaris                                      MM-170504
\ ------------------------------------------------------------------------------

\             Copyright (C) 2017-2020 Manfred Mahlow @ forth-ev.de

\        This is free software under the GNU General Public License v3.
\ ------------------------------------------------------------------------------
\ This is an implementation of a subset of words from the Forth Search-Order
\ word set.

\ ** This file must be loaded only once after a RESET (the dictionary in RAM 
\    must be empty) and before any new defining word is added to Mecrisp-
\    Stellaris. It is and needs to be compiled to FLASH.

\ ** Requires 

\    Mecrisp-Stellaris  2.3.6-hook-find  or  2.3.8-ra  or a later version with
\    hook-find.

     ' hook-find drop

\ ** Recommends

\    Terminalprogram: e4thcom -t mecrisp-st -b B115200


\ * The Forth Search-Order and three wordlists are added:
\
\   FORTH-WORDLIST
\
\       \WORDS          ( -- )
\       FORTH-WORDLIST  ( -- wid )
\       INSIDE-WORDLIST ( -- wid )
\       ROOT-WORDLIST   ( -- wid )
\       WORDLIST        ( -- wid )
\       SHOW-WORDLIST   ( wid -- )
\       GET-ORDER       ( -- wid1 ... widn n )  
\       SET-ORDER       ( wid1 ... widn n | -1 -- )
\       SET-CURRENT     ( wid -- )
\       GET-CURRENT     ( -- wid )
\
\   ROOT-WORDLIST
\
\       INIT            ( -- )
\       WORDS           ( -- )
\       ORDER           ( -- )
\
\   INSIDE-WORDLIST
\   holds words needed for the implementation but normally not required for
\   applications.
\
\
\ * The default search order is FORTH-WORDLIST FORTH-WORDLIST ROOT-WORDLIST.
\
\ * The search order can be changed with GET-ORDER and SET-ORDER.
\
\ * Dictionary searching is done by the new word FIND-IN-DICTIONARY (defined in
\   the INSIDE-WORDLIST). It is called via HOOK-FIND by the now vectored Mecrisp
\   word FIND .
\
\ * New words are added to the FORTH-WORDLIST by default. This can be changed
\   by setting a new compilation context with <wordlist> SET-CURRENT.
\
\ * Compiling to FLASH and RAM is supported. 
\
\ * The curious may take a look at the implementation notes at the end of this
\   file.
\
\ Some usage examples:
\
\   WORDLIST constant <name>  Creates an empty wordlist and assigns its wid to
\                             a constant.
\
\   <name> SHOW-WORDLIST      Lists all words of the wordlist <name>.
\
\   GET-ORDER NIP <name> SWAP SET-ORDER
\
\                             Overwrites the top of the search order.
\
\   <name> SET-CURRENT        Overwrites the compilation wordlist.
\
\   WORDS                     Lists all words of the top of the search order.
\                             ( initially this is the FORTH-WORDLIST )
\
\   \WORDS                    Alias for the word WORDS defined in the Mecrisp
\                             core. Ignores all wordlist related information. 
\                             Might be useful in special debuging situations.
\
\   INIT                      Initialisation of the wordlists extension.
\
\ ------------------------------------------------------------------------------

  compiletoflash      \ This extension must be compiled in flash.

  hex

\ An alias for WORD in the Mecrisp Stellaris core.
: \words ( -- ) words ;


\ Three wordlists are implemented now, all as members of the forth-wordlist:

   align 0 , here cell+ ,     here constant forth-wordlist

   align 0 , forth-wordlist , here constant inside-wordlist

   align 0 , forth-wordlist , here constant root-wordlist


  forth-wordlist ,
\ Return a wordlist identifier for a new empty wordlist.
: wordlist ( -- wid )
\ align here 0 ,                               MM-200522
  align here [ here @ not literal, ] ,
;

  inside-wordlist ,
\ Return true if lfa|wid is the wid of a wordlist.     MM-200522
: wid? ( lfa|wid -- f )
  @ [ here @ not literal, ] =
;

  inside-wordlist ,
\ lfa of the first word in flash
  dictionarystart constant _sof_


\ We need two buffers for the FORTH search order:

  inside-wordlist ,
  #6 constant #vocs 

\ A buffer for the search order in compiletoflash mode.
  inside-wordlist ,
  #vocs 1+ cells buffer: c2f-context


\ A buffer for the search order in compiletoram mode.
  inside-wordlist ,
  #vocs 1+ cells buffer: c2r-context

  inside-wordlist ,
\ Return the addr of the actual search order depending on the compile mode.
: context ( -- a-addr )
  compiletoram? if c2r-context else c2f-context then
;


  inside-wordlist ,
\ Current for the compiletoflash mode.
  forth-wordlist variable c2f-current

  inside-wordlist ,
\ Current for the compiletoram mode.
  forth-wordlist variable c2r-current

  inside-wordlist ,
\ Current depending on the compile mode.
: current ( -- a-addr )
  compiletoram? if c2r-current else c2f-current then
;


  inside-wordlist ,
\ A buffer to register a context switching request.
  0 variable _csr_

  inside-wordlist ,
\ A buffer for some flags in a wordlist tag (wtag).
  0 variable wflags


  inside-wordlist ,
\ A flag, true for searching the dictionary with context switching support,
\ false for searching the compilation context only without context switching.
  -1 variable _indic_ 


  inside-wordlist ,
\ Compile a wordlist tag ( wtag).
: wtag, ( -- )
  align current @ wflags @ or ,  0 wflags !  0 _indic_ !
;


  inside-wordlist ,
: lfa>flags ( a-addr1 -- a-addr2 ) cell+ ;

  inside-wordlist ,
: lfa>nfa ( a-addr -- cstr-addr ) lfa>flags 2+ ;

  inside-wordlist ,
: lfa>xt ( a-addr -- xt ) lfa>nfa skipstring ;

  inside-wordlist ,
: lfa>wtag ( a-addr -- wtag ) [ 1 cells literal, ] - @ ;

  inside-wordlist ,
: lfa>ctag ( a-addr -- ctag ) [ 2 cells literal, ] - @ ;

  inside-wordlist ,
: tag>wid ( wtag -- wid ) [ 1 cells 1- not literal, ] and ;

  inside-wordlist ,
: lfa>xt,flags ( a-addr -- xt|0 flags )
  dup if dup lfa>xt swap lfa>flags h@ else dup then
;


\ Tools to display wordlists:

  inside-wordlist ,
: .id ( lfa -- )
  lfa>nfa count type space
;

  inside-wordlist ,
: .wid ( lfa|wid -- )
\ dup @ if ( wid = lfa ) .id else u. then
  dup wid? if u. else .id then
;


  inside-wordlist ,
\ Print some word header information.
: .header ( lfa -- )
  ." lfa: " dup hex. dup ." xt: " lfa>xt hex.    \ print lfa and xt
  ." name: " lfa>nfa count type space            \ print name
;


  inside-wordlist ,
: .wtag ( wtag -- ) ." wtag: " hex. ;

  inside-wordlist ,
: .ctag ( ctag -- ) ." ctag: " hex. ;


  inside-wordlist ,
\ Return true if the word at lfa is smudged.
: smudged? ( lfa -- flag )
\ cell+ h@ FFFF <>
  cell+ h@ [ here @ FFFFFFFF = FFFF and literal, ] <>   \ MM-200520
;


  inside-wordlist ,
\ Show the word at lfa if its a member of the wordlist wid.
: show-wordlist-item ( lfa wid -- )
  >r dup forth-wordlist >=   \ tagged word ?
  if ( lfa )
    dup lfa>wtag tag>wid r@ =     \ wid(lfa) = wid
    if ( lfa )
     \ long version
       cr dup lfa>wtag dup 1 and if over lfa>ctag .ctag else #15 spaces then
       .wtag .header
     \ short
       \ .id space
    else
      drop
    then
  else ( lfa )
   \ long
     cr #30 spaces .header
   \ short
     \ .id space
  then
  r> drop
;


  inside-wordlist ,
: show-wordlist-item ( lfa wid -- )                        \ MM-200520
  over smudged? if show-wordlist-item else 2drop then
;
  


  inside-wordlist ,
: show-wordlist-in-ram ( wid lfa -- )
  drop ( wid ) >r
  dictionarystart ( lfa )
  begin
    dup _sof_ <>
  while
    dup r@ show-wordlist-item
    dictionarynext if drop _sof_ then
  repeat
  r> 2drop ;


  inside-wordlist ,
\ : show-wordlist-in-flash ( wid lfa -- )
: show-wordlist-in-flash ( wid lfa -- )
\ List all words of wordlist wid (defined in flash) starting with word at lfa.
\ lfa must be in flash
\ forth-wordlist dictionarystart c2f-... lists all forth-wordlist words
\ forth-wordlist dup             c2f-... lists forth-wordlist words starting
\                                        with lfa(forth-wordlist)
\ wid dup                        c2f-... lists all words of wordlist wid
  swap >r  ( lfa ) ( R: wid )
  begin ( lfa )
    dup r@ show-wordlist-item
    dictionarynext 
  until
  r> 2drop
;


  forth-wordlist ,
\ Show all words of the wordlist wid.
: show-wordlist ( wid -- )
  dup forth-wordlist =
  if dup _sof_ else dup forth-wordlist then show-wordlist-in-flash
  compiletoram? if 0 show-wordlist-in-ram else drop then
;

\ End of Tools to display wordlists.


  inside-wordlist ,
\ Return true if name of word at lfa equals c-addr,u and word is smudged.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: name? ( c-addr u lfa -- c-addr u lfa flag )
  >r 2dup r@ lfa>nfa count compare r> swap
  if  ( c-addr u lfa )  \ name = string c-addr,u
      dup smudged?
  else  \ name <> string c-addr,u
    false
  then
;


  inside-wordlist ,
\ If the word with name c-addr,u is a member of wordlist wid, return its lfa.
\ Otherwise return zero.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: search-wordlist-in-ram ( c-addr u wid -- lfa|0 )
  >r dictionarystart 
  begin ( c-addr u lfa )
    dup _sof_ <> 
  while ( c-addr u lfa )
    dup lfa>wtag tag>wid r@ =        \ wid(lfa) = wid ?
    if
      name?   ( c-addr u lfa flag )
      if
        nip nip r> drop exit
      then
    then
    dictionarynext drop
  repeat 
  ( c-addr u lfa ) 2drop r> ( c-addr wid ) 2drop 0
;


  inside-wordlist ,
\ If the word with name c-addr,u is a member of wordlist wid, return its lfa.
\ Otherwise return zero.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: search-wordlist-in-flash ( c-addr u wid -- lfa|0 )
  dup 0 >r >r forth-wordlist = if _sof_ else forth-wordlist @  then
   begin
    dup forth-wordlist >           \ tagged word ?
    if
      dup lfa>wtag tag>wid r@ =    \ wid(lfa) = wid ?
      if
        name?
        if
          r> r> drop over >r >r         \ R: wid lfa.found
          \ for debugginng only :
          \ cr dup lfa>wtag .wtag dup .header  \ print wtag(lfa) and name(lfa)
          \
        then
      then
    else ( c-addr u lfa )
      name?
      if 
        r> r> drop over >r >r           \ R: wid lfa.found
        \ for debugginng only :
        \ cr 9 spaces dup .header
        \
      then
    then
    dictionarynext
  until
  ( c-addr u lfa ) 2drop r> ( c-addr wid ) 2drop
  r> ( lfa|0 )
;


  inside-wordlist , 
\ If the word with name c-addr,u is a member of wordlist wid, return its lfa.
\ Otherwise return zero.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: search-in-wordlist ( c-addr u wid -- lfa|0 )
  >r compiletoram?
  if
    2dup r@ search-wordlist-in-ram ?dup if nip nip r> drop exit then
  then
  r> search-wordlist-in-flash
;


  inside-wordlist ,
\ Search the word with name c-addr,u in the search order at a-addr. If found
\ return the words lfa otherwise retun 0.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: search-in-order ( c-addr u a-addr -- lfa|0 )
  dup >r ( c-addr u a-addr )  \ a-addr = top of the search order
  begin
    @ ( c-addr u wid|0 ) dup
  while
    >r 2dup r> search-in-wordlist dup
    if nip nip r> drop exit then drop
    r> cell+ dup >r
  repeat
  r> 2drop 2drop 0
;


  inside-wordlist ,
\ Search the dictionary for the word with the name c-addr,u. Return xt and flags
\ if found, 0 and invalid flags otherwise.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: find-in-dictionary ( c-addr u -- xt|0 flags )
  context search-in-order ( lfa ) lfa>xt,flags
;


  inside-wordlist ,
\ Return the number of wordlists (wids) in the search order.
: w/o ( -- wid1 ... widn n )
  0 context begin dup @ while swap 1+ swap cell+ repeat drop
; 

  forth-wordlist ,
: get-order ( -- wid1 ... widn n )
  w/o dup 0= if exit then 
  dup >r cells context +
  begin 1 cells - dup @ swap dup context = until drop r>
;

  forth-wordlist ,
: set-order ( wid1 ... widn n | -1 )
   dup #vocs > if ." order overflow" cr quit then
   dup -1 = if drop root-wordlist forth-wordlist dup 3 then
   dup >r 0 ?do i cells context + ! loop
   0 r> cells context + !  \ zero terminated order
;


  forth-wordlist ,
: set-current ( wid -- ) current ! ;

  forth-wordlist ,
: get-current ( -- wid ) current @ ;


  inside-wordlist ,
: ?words ( wid f -- )
\ If f = -1 do not list the mecrisp core words.
\  context @ 
\  swap if
   if ( wid )
    \ Show words in flash starting with FORTH-WORDLIST.
    dup forth-wordlist
  else
    \ Show words in flash starting with the first word in flash.
\   dup forth-wordlist over = if _sof_ else forth-wordlist then  \ fails MM-200102
    dup dup forth-wordlist = if _sof_ else forth-wordlist then   \ works
  then
  show-wordlist-in-flash
  dup cr ." << FLASH: " .wid
  compiletoram?
  if
    cr dup ." >> RAM:   " .wid 
    0 show-wordlist-in-ram
  else
     drop
  then
;

  forth-wordlist ,
: words ( -- ) context @ 0 ?words ;

  root-wordlist ,
  : words ( -- ) words ;

  root-wordlist ,
\ Display the search order and the compilation context.
: order ( -- ) 
  cr ." context: " get-order 0 ?do .wid space loop
  cr ." current: " current @ .wid
  ."  compileto" compiletoram? if ." ram" else ." flash" then
;


\ We have to redefine all defining words of the Mecrisp Core to make them add
\ a wordlist tag when creating a new word:
\ ------------------------------------------------------------------------------
  forth-wordlist ,
  : : ( "name" -- ) wtag, : ;

  forth-wordlist set-current

: constant  wtag, constant ;
: 2constant wtag, 2constant ;

: variable  wtag, variable ;
: 2variable wtag, 2variable ;
: nvariable wtag, nvariable ;

: buffer: wtag, buffer: ;

: (create) wtag, (create) ;
: create   wtag, create ;
: <builds  wtag, <builds ;
\ ------------------------------------------------------------------------------

: abort ( -- ) cr quit ;  \ required for e4thcom error detection


inside-wordlist set-current  \ MM-200419

: wlst-init ( -- )
  compiletoflash -1 set-order  compiletoram -1 set-order  \ init both orders
  ['] find-in-dictionary hook-find !
;

root-wordlist set-current   \ MM-191228

\ MM-200419   (C) message only on reset

\ Finally we have to redefine INIT to set HOOK-FIND to call FIND-IN-DICTIONARY.
: init ( -- )
  hook-find @ ['] find-in-dictionary <
  if
    ." Wordlist Extension 0.8.3 for Mecrisp-Stellaris by Manfred Mahlow" cr
  then
  wlst-init
; 

init   \ Init the wordlist extension.

decimal

\ ------------------------------------------------------------------------------
\ Last Revision: MM-200522 0.8.4 : wordlist changed  wid? added  .wid changed
\                MM-200520 smudge? changed
\                MM-200419 0.8.3
\                          init changed to only display (C) message on reset
\                MM-200122 Final review of release 0.8.2.
\
\                MM-170604 First test implementation (feasibilty test)

\ ------------------------------------------------------------------------------
\ Implementation Notes:
\ ------------------------------------------------------------------------------
\ The code was created with Mecrisp-Stellaris 2.3.6 lm4f120 and tm4c1294 and
\ finally tested with Mecrisp-Stellaris 2.5.0 lm4f120-ra, msp432p401r-ra and
\ tm4c1294-ra. 

\ Wordlists are not implemented as separate linked lists but by tagging words
\ with a wordlist identifier (wid). The tags are evaluated to find a word in a 
\ specific wordlist. This idea was taken from noForth V. 

\ The main difference to noForth is, that not all words are tagged but only 
\ those, created after loading this extension. So only one minor change of the
\ Mecrisp-Stellaris Core was required: FIND had to be vectored (via HOOK-FIND).

\ A look at the Mecrisp-Stellaris dictionary structure shows, that a list entry
\ (a word) can be prefixed with the wid of the wordlist, the word belongs to.
\ This is what is done in this implementation.
\ ------------------------------------------------------------------------------

\ Address: 00004000 Link: 00004020 Flags: 00000081 Code: 0000400E Name: current
\ Address: 00004020 Link: 0000404C Flags: 00000000 Code: 00004030 Name: variable
\ Address: 0000404C Link: FFFFFFFF Flags: 00000000 Code: 0000405A Name: xt>nfa

\ 0404C         | Address (lfa) , holds the address of the next word or -1
\               |
\               |
\               |
\ cell+ = 04050 | Flags, 2 bytes    = lfa>flags
\         04051 |
\         04052 : 06     Name (nfa) = lfa>nfa
\         04053 : x
\               : t
\               : >
\               : n
\               : f
\               : a
\         04059 : 0    alignment
\ 405A          : Code (xt)         = lfa>xt = lfa>nfa skipstring

\ ------------------------------------------------------------------------------

\ After loading wordlists.txt all new words are prefixed/tagged with a wordlist-
\ tag ( wtag ).

\ wtag = wid || wflags

\  wid = identifier of the wordlist, the word belongs to

\  wflags = the 1 cells 2 / lowest bits of a wtag

\  we are only using Bit0 here (to be 16 Bit compatibel)

\   Filename: vis-0.8.4-core.fs
\    Purpose: Adds VOCs, ITEMs and STICKY Words to Mecrisp-Stellaris
\        MCU: *
\      Board: * , tested with TI StellarisLaunchPad 
\       Core: Mecrisp-Stellaris by Matthias Koch.
\   Required: wordlists-0.8.4.fs for Mecrisp-Stellaris
\     Author: Manfred Mahlow          manfred.mahlow@forth-ev.de
\   Based on: vocs-0.7.0
\    Licence: GPLv3
\  Changelog: 2020-04-19 vis-0.8.2-core.txt --> vis-0.8.3-core.fs
\             2020-05-22 vis-0.8.4-core.fs  minor changes

\ Source Code Library for Mecrisp-Stellaris                           MM-170628
\ ------------------------------------------------------------------------------
\              Vocabulary Prefixes ( VOCs ) for Mecrisp-Stellaris
\
\              Copyright (C) 2017-2020 Manfred Mahlow @ forth-ev.de
\
\        This is free software under the GNU General Public License v3.
\ ------------------------------------------------------------------------------
\ Vocabulary prefixes ( VOCs ) help to structure the dictionary, make it more 
\ readable and can reduce the code size because of shorter word names.
\
\ Like VOCABULARYs VOCs are context switching words. While a vocabulary changes
\ the search order permanently, a VOC changes it only temporarily until the next
\ word from the input stream is interpreted. VOCs are immediate words.
\
\ VOCABULARYs and VOCs are words for explicit context switching.
\
\ This extension also supports implicit context switching ( see the words ITEM
\ and STICKY ) and (single) inheritanc for VOCs.

\ Implicit Context Switching:

\ Implicit context switching means that a "normal" Forth word is tagged with
\ the wordlist identfier (wid) of a VOC. When Forths outer interpreter FINDs
\ such a word, it is executed or compiled as normal (depending on STATE) and
\ the VOCs search order is set as the new search context. The next word from 
\ the imput stream is then found in this context and afterwards the search
\ context is reset to the "normal" Forth search order.

\ Inheritance:

\ Inheritance means that a new VOC can inherit from (can extend) an existing
\ one. The search order of the new VOC is then the VOCs wordlist plus the 
\ inherited VOCs search order.

\ So VOCs can be used to create libraries, register identifiers, data types
\ and to define classes for objects with early binding methods and (single)
\ inheritance.

\ Give it a try and you will find that VOCs are an easy to use and powerful
\ tool to write well factored code and code modules.

\ Glossary:

\ voc ( "name" -- )  Create a vocabulary prefix that extends the voc root.

\ <voc> voc ( "name" -- )  Create a vocabulary prefix that extends (inherits 
\                          from) the given voc.

\ <voc> ?? ( -- )   Show all words of the actual VOC search order and stay in
\                   that VOC context.

\ .. ( -- )  Switch back from a VOC search order to the default Forth search
\            order.

\ <voc> definitions ( -- )  Make <voc> the current compilation context.

\ <voc> item ( -- )  Make the next created word a context switching one, i.e. 
\                    #123 int item variable int1  \ int1 ( -- a ; NS: int )

\ sticky ( -- )  Make the next created word a sticky one.

\ @voc ( -- )  Make the current compilation context the actual search context.

\ init ( -- )  Initialize the VOC extension.

\ ------------------------------------------------------------------------------

\ This extension must be compiled in FLASH.

compiletoflash

root-wordlist set-current  hex

: vis ( -- ) ." 0.8.4" ;

\ inside-wordlist first
get-order nip inside-wordlist swap set-order

inside-wordlist set-current


\ VOC context pointer for the compiletoflash mode.
  root-wordlist variable c2f-voc-context


\ VOC context pointer for the compiletoram mode.
  root-wordlist variable c2r-voc-context


\ VOC context pointer
: voc-context ( -- a-addr )
  compiletoram? if c2r-voc-context else c2f-voc-context then ;


\ Now that we have two context pointers ( context and voc-context ) representing
\ two search orders in two compile modes , we need a global search order pointer
\ too.


\ Search order pointer for the compiletoflash mode.
  c2f-context variable _c2f-sop_


\ Search order pointer for the compiletoram mode.
  c2r-context variable _c2r-sop_


\ Return the addr of the search oder pointer depending on the compile mode.  
  : _sop_ ( -- a-addr ) compiletoram? if _c2r-sop_ else _c2f-sop_ then ; 


\ Save the context switching request of the word with address lfa.
: _!csr_ ( lfa -- )
    0 _csr_ ! dup
    if ( lfa ) \ found
      \ *** for context switching debugging only
      \ ."  found: " dup .header 
      ( lfa ) dup forth-wordlist >   \ tagged word ?
      if ( lfa ) 
        dup lfa>wtag ( lfa wtag ) 1 and   \ word with ctag ?
        if dup lfa>ctag ( csr ) _csr_ ! then ( lfa )
      then ( lfa )
    then ( lfa )
    drop 
;


\ Process the last saved context switching request. 
: _?csr_ ( -- )
    \ *** for context switching debugging only
    \ cr _csr_ @ ." _csr_=" .
    \ postponed context switch request ? reset postpone flag csr.0 and exit
    _csr_ @ dup 1 and if -2 and _csr_ ! exit then ( csr|0 ) dup
    if ( csr )  \ context switching requested
       voc-context !  0 _csr_ !  voc-context
    else ( 0 )
      drop context
    then
    _sop_ !
;


\ Given a VOCs wid return the wid of the parent voc or zero if no voc was
\ inherited.
\ : vocnext ( wid1 -- wid2|0 ) [ 2 cells literal, ] - @ ;

\ MM-200103 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
\ Given a vocs wid return the wid of the parent voc or zero if no voc was
\ inherited. Return 0 if wid is the wid of a wordlist.
  : vocnext ( wid1 -- wid2|0 )
    dup @ if [ 2 cells literal, ] - @ else dup - then ;


\ Search the VOCs search order (voc-context) at a-addr for a match with the
\ string c-addr,len. If found return the address (lfa) of the dictionary entry,
\ otherwise return 0.
: search-in-vocs ( c-addr len a-addr -- lfa|0 )
  @
  begin
   \ dup .
   >r 2dup r@ search-in-wordlist dup if nip nip r> drop exit then drop
   r> vocnext dup 0= 
  until
  drop root-wordlist search-in-wordlist
;

\ ------- MM-200110 -----------

\ The search-in-order defined in wordlists only searches the top wordlist of
\ every search order entry. To seach all wordlists except root of every entry
\ search-in-order must be overwriten as follows:

: search-in-vocs-without-root ( c-addr len a-addr -- lfa|0 )
\ @     MM-200102  !!!!!!!!!!!!
  begin
   \ dup .
   >r 2dup r@ search-in-wordlist dup if nip nip r> drop exit then drop
   r> vocnext dup 0= 
  until
  nip nip
;

\ from wordlists.txt

\ Search the word with name c-addr,u in the search order at a-addr. If found
\ return the words lfa otherwise retun 0.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: search-in-order ( c-addr u a-addr -- lfa|0 )
  dup >r ( c-addr u a-addr )  \ a-addr = top of the search order
  begin
    @ ( c-addr u wid|0 ) dup
  while
\    >r 2dup r> search-in-wordlist dup      \ old search  MM-200101
\ -- new search
    \ dup .id                                                     
    >r 2dup r> dup root-wordlist =
    if \ ."  swl "
      search-in-wordlist
    else \ ."  svoc "
      search-in-vocs-without-root
    then
    dup 
\ --
    if nip nip r> drop exit then drop
    r> cell+ dup >r
  repeat
  r> 2drop 2drop 0
;

\ ------------------------------

\ Search the dictionary for a match with the given string. If found return the
\ lfa of the dictionary entry, otherwise return 0.
\ Note: Based on mecrisps case insensitive non-ANS compare  !!!!!
: search-in-dictionary ( c-addr len -- lfa|0 )
  _sop_ @ dup context =
  if   \ ."  in order "  dup @ .id    \ MM-191226
    search-in-order
  else  \ ."  in voc "  dup @ .id
    search-in-vocs
  then
;

\ Search the dictionary for a match with the given string. If found return the 
\ xt and the flags of the dictionary entry, otherwise return 0 and flags.
\ Note: Based on mecrisps case insensitive non-ANS compare.
: vocs-find ( c-addr len -- xt|0 flags )
  _indic_ @ 
  if
    _?csr_
    \  ." voc-find,_indic_ = -1 "              \ *** for debugging only
    search-in-dictionary ( lfa )
    dup _!csr_
    \  ."  csr=" _csr_ @ . cr     \ *** for debugging only
  else ( lfa )
    \ ." voc-find,_indic_ = 0 "              \ *** for debugging only
    -1 _indic_ ! current @ search-in-wordlist
  then
  lfa>xt,flags
;

: (dovoc ( wid -- )
  _csr_ ! _?csr_ 1 _csr_ !   \ 190724
;

: dovoc ( a -- )
  @ (dovoc                   \ 190724
;


\ MM-190721-24
\ Create a VOC that extends the VOC wid (inherits from VOC wid).
: voc-extend ( "name" wid -- )
  \ compile the VOCs itag ( the wid of the inherited VOC )
    align ,
  \ create the VOC as an immediate word
   2 wflags !  \ set voc-flag in wtag
   here ( addr of names wtag ) cell+ ( lfa of name )
\  <builds , postpone immediate    \ MM-191226    
   <builds , [ ' immediate call, ] 
    does> dovoc 
;


: vocs-quit ( -- )
  0 _csr_ !  context _sop_ !
  \ ." reset "  \ only for debugging
  [ hook-quit @ literal, ] execute
;


root-wordlist set-current   \ Some tools needed in VOC contexts


\ Switch back from a VOC search order (voc-context) to the FORTH search order.
: .. ( -- )
  0 _csr_ !  _?csr_  immediate
;


: definitions ( -- ) 
\ _SOP_ @ @ set-current postpone .. immediate ;      \ MM-191226
  _SOP_ @ @ set-current [ ' .. call, ] immediate ;


\ Create a VOC that extends (inherits from) the actual VOC context.
 : voc ( "name" -- )
  _sop_ @ CONTEXT = if 0 else VOC-context @ then voc-extend
;


: first ( -- )
\ <voc> first overwrite the top of the permanent search order with the top wid
\ of the current temporary search order.
\  _sop_ @ @ context ! postpone .. immediate ;       MM-191226
\  _sop_ @ @ context ! \.. immediate ;               MM-191227
  _sop_ @ @ context !  [ ' .. call, ] immediate ;


\ Make the current compilation context the new search context.
: @voc ( -- )
  get-current (dovoc immediate
;


\ inside-wordlist first

get-order nip inside-wordlist swap set-order


 2 wflags !
 : root ( -- )   root-wordlist   (dovoc  immediate ;
 2 wflags !
 : inside ( -- ) inside-wordlist (dovoc  immediate ;
 2 wflags !
 : forth ( -- )  forth-wordlist  (dovoc  immediate ;


\ Make the next created word a context switching one (assign a ctag).
\ Usage: <voc> item <defining word> ...   i.e.:  123 item variable i1
: item ( -- )
  \ compile the actual VOCs wid as the next created words ctag
    align voc-context @ ,
  \ set bit 0 of the wflags in the next created words wtag
    1 wflags !
\    [ ' .. call, ]  \ MM-200105  MM-200106
;


\ Make the next created word a sticky one.
  : sticky ( -- ) align 1 , 1 wflags ! ;


\ Print the data stack and stay in the current context.
\  sticky   MM-191228
  : .s ( -- ) .s ;


inside-wordlist set-current

\ MM-200419  (C) message only on reset

\ Initialize Mecrisp with wordlist and voc extension.
: voc-init ( -- )
  hook-find @ ['] vocs-find <
  if
    ." VIS " vis
    ." : VOCs ITEMs and STICKY Words for Mecrisp-Stellaris by Manfred Mahlow"
    cr
  then
  wlst-init  ['] vocs-quit hook-quit !  ['] vocs-find hook-find !
;

\ inside-wordlist first
get-order nip inside-wordlist swap set-order

root-wordlist set-current

: init ( -- ) voc-init ;

\ forth-wordlist first
get-order nip forth-wordlist swap set-order

forth-wordlist set-current

init  \ now vocs can be used.


compiletoflash

: find ( a u -- xt|0 flags )  \ MM-200522
  inside first  search-in-dictionary lfa>xt,flags  forth first ;

\ MM-200521

root definitions  inside first

: (' ( "name" -- lfa )
  token search-in-dictionary ?dup if exit then ."  not found." abort
;  

forth definitions

: ' ( "name" -- xt ) (' lfa>xt ;  \ MM-200522

: ['] ( "name" -- ) ' literal, immediate ;

\ postpone needs to be redefined because the core word has an internal tick
\ dependency, that is not fullfilled, when the new find is used.

: postpone ( "name" -- )   \ MM-191227
  (' inside lfa>xt,flags dup $10 and if drop call, exit then  \ MM-200519
  drop literal, ['] call, call,  immediate
;


root definitions

: ' ( "name" -- ) ' ;

: ['] ( "name" -- ) postpone ['] immediate ;

: postpone ( "name" -- ) postpone postpone immediate ;

  forth first definitions  decimal

compiletoram

\ ------------------------------------------------------------------------------
\ Last Revision: MM-200522 0.8.3 : voc-init changed to only display (C) message
\                          on reset  find and (' added  ' and postpone changed  
\                MM-200122 0.8.2 revision
\ ------------------------------------------------------------------------------
\ Implementation Notes:
\ ------------------------------------------------------------------------------
\ After loading wordlists.txt all new words are prefixed/tagged with a wordlist-
\ tag ( wtag ).

\ wtag = wid || wflags

\  wid = identifier of the wordlist, the word belongs to

\  wflags = the 1 cells 2 / lowest bits of a wtag

\  we are only using Bit0 here (to be 16 Bit compatibel)


\ To make a word a context switching one, it's additionally prefixed with a 
\ context-tag ( ctag ) and bit wflags.0 is set.

\ ctag = wid || cflags

\ wid = identifier of the wordlist, to be set as top of the actual search order
\       after interpreting the word

\ cflags = the 1 cells 2 / lowest bits of a ctag ( not yet used )


\ Context switching is done by FIND-IN-Dictionary which is hooked to HOOK-FIND :

\ * Before searching the dictionary, it is checked ( by ?cps ), if the last 
\   interpreted word requested to change the search context. Then it's done.

\ * After a successful dictionary search it is recorded ( by !cps ) if a context
\   switch is requested. Then it will then be done ( by ?csp ) before the next
\   search.

\ * If an error occures, the search context is reset to the systems default
\   search order.


\   Filename: vis-0.8.4-??.fs
\    Purpose: Adds the VIS dictionary browser to Mecrisp-Stellaris
\        MCU: *
\      Board: * , tested with TI StellarisLaunchPad 
\       Core: Mecrisp-Stellaris by Matthias Koch.
\   Required: vis-0.8.4-core.fs for Mecrisp-Stellaris
\     Author: Manfred Mahlow          manfred.mahlow@forth-ev.de
\   Based on: vocs-0.7.0
\    Licence: GPLv3
\  Changelog: 2020-04-19 vis-0.8.2-??.txt --> vis-0.8.2-??.fs
\             200522 vis-0.8.4-??.fs  vid redefined  ?wid changed
\                                     .nid and core? new

\ Source Code Library for Mecrisp-Stellaris                           MM-190718
\ ------------------------------------------------------------------------------

  compiletoflash

  inside first definitions  decimal

: ?wid ( wid1 -- wid1|wid2 )
  dup root-wordlist   = if drop [ (' root   literal, ] exit then
  dup forth-wordlist  = if drop [ (' forth  literal, ] exit then
  dup inside-wordlist = if drop [ (' inside literal, ] exit then

;

: .wid ( wid -- ) ?wid .wid ;

: core? ( lfa -- f ) \ true if lfa is in the mecrisp core
  _sof_ @ u>= over forth-wordlist u< and
;

\ Given a words lfa print its name with allVOCabulary prefixes. If it's  a
\ word from the Stellaris core do not print the prefix forth.
: .nid ( lfa -- )  \ MM-200522
\  dup _sof_ @ u>= over forth-wordlist u< and if .id exit then
  dup core? if .id exit then
  0 swap
  begin
    dup lfa>wtag tag>wid
    dup forth-wordlist =
    if
      over dup forth-wordlist u>= swap root-wordlist u<= and if drop then -1
    else
      dup wid?
    then
  until
  over if dup forth-wordlist = if drop then then  \ no forth prefix  MM-200522
  begin
    dup
  while
    .wid     
  repeat
  drop
;

\ Given a wid of a VOCabulary print the VOCabulary name, given a wid of a
\ wordlist print the address.
: .vid ( wid -- )  \ MM-200522
  tag>wid
  dup wid? if .wid exit then
  .nid
;

root definitions

\ Display the search order, the compilation contex and the compilation mode.
: order ( -- ) 
  cr ." context: "
  _sop_ @ context =
  if  \ default search order
    context
    begin
      dup @ dup
    while
      .vid space cell+
    repeat
    2drop
  else  \ voc search order
    voc-context @
    begin
      dup .vid space vocnext dup 0=         \ MM-200102
    until
    drop root-wordlist .wid space
  then
  cr ." current: " current @ .vid space
  ." compileto" compiletoram? if ." ram" else ." flash" then
;


 inside definitions

: dashes ( +n -- ) 0 ?do [char] - emit loop ;

: ?words ( wid f -- )
\ If f = -1 do not list the mecrisp core words.
  if  ( wid )
    \ Show words in flash starting with FORTH-WORDLIST.
    dup forth-wordlist
  else  ( wid )
    \ Show words in flash starting with the first word in flash.
\   dup forth-wordlist over = if _sof_ else forth-wordlist then  \ fails MM-200102
    dup dup forth-wordlist = if _sof_ else forth-wordlist then   \ works
  then
  show-wordlist-in-flash 
  dup cr ." << FLASH: " .vid
  compiletoram?
  if
    cr dup ." >> RAM:   " .vid
    0 show-wordlist-in-ram
    cr 15 dashes
  else
     drop
  then
;

: \?? ( f -- ) 
    cr 15 dashes
    >r _sop_ @ @ ( lfa|wid ) 
    begin
      dup r@ ?words \ cr
      vocnext dup 0=
    until
    r> 2drop
;

  forth definitions

  : words ( -- ) 0 \?? cr ;

  root definitions

  : words ( -- ) words ;

  sticky : ?? ( -- )
  -1 \?? order ."   base: " base @ dup decimal u. base !  cr 2 spaces .s ;

  forth first definitions  decimal

\ Last Revision: MM-200522 vis-0.8.4-??.fs  vid redefined  ?wid changed 
\                          ?vid removed  .nid new
\                MM-200108 ?voc-words --> ?words

\ vis-0.8.2-also.txt    Source Code Library for Mecrisp-Stellaris      MM-191228
\ ------------------------------------------------------------------------------
  compiletoflash

  root definitions  decimal  inside first

  : only ( -- )
    [ root .. voc-context @ literal, forth .. voc-context @ literal, ] 
    dup 3 set-order  immediate ;

  : also ( -- ) 
    get-order dup #vocs = if ."  ? search order overflow " abort then
    over swap 1+ set-order  postpone first  immediate ;
\   over swap 1+ set-order [ ' first call, ] immediate ;

  : previous ( -- )
    get-order dup 1 = if ."  ? search order underflow " abort then
    nip 1- set-order immediate ;

  forth definitions  forth first

\ Last Revision: MM-200122

\ vis-0.8.2-vocs.fs     Source Code Library for Mecrisp-Stellaris     MM-191228
\ ------------------------------------------------------------------------------

inside first definitions  decimal

: ?voc ( lfa --) dup lfa>wtag 3 and 2 =  if space space .vid else drop then ;

forth definitions

\ Show all the VOCs that are actually defined in the dictionary.
: vocs ( -- )
  cr ." FLASH: "   \ show VOCs defined in FLASH
  forth-wordlist
  begin
    dup ?voc dictionarynext
  until
  drop
  compiletoram?
  if
    cr ."   RAM: "   \ show VOCs define in RAM
    dictionarystart ( lfa )
    begin
      dup _sof_ <>
    while
      dup ?voc dictionarynext if drop _sof_ then
    repeat
    drop
  then
  space
;

forth first

\ Last Revision: MM-200522 minor edit

\ vis-0.8.3-items.fs    Source Code Library for Mecrisp-Stellaris     MM-191228
\ ------------------------------------------------------------------------------

  compiletoflash

  inside first definitions  decimal

: ?item ( lfa --) dup lfa>wtag 3 and 1 = 
   if
      3 spaces
      dup lfa>ctag dup 1 = if drop ." sticky " else tag>wid .vid then 
      $08 emit ." : " .vid
   else
     drop
   then ;


  forth definitions

\ Show all context switching items which are actually defined in the dictionary.
: items ( -- )
  cr ." FLASH:"  \ show items defined in FLASH
  forth-wordlist
  begin
    dup ?item
    dictionarynext
  until
  drop
  compiletoram?
  if
    cr ."   RAM:"  \ show items defined in RAM
    dictionarystart ( lfa )
    begin
      dup _sof_ <>
    while
      dup ?item
      dictionarynext if drop _sof_ then
    repeat
    drop 
  then
  space
;

  forth first

\ Last Revision: MM-200522 ?vid --> .vid

compiletoram  \ EOF vis-0.8.4-mecrisp-stellaris.fs 
 
