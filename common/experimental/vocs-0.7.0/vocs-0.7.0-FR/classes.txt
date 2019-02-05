\ classes.txt        Source Code Library for Mecrisp-Stellaris        MM-170628
\ ------------------------------------------------------------------------------
\     Classes, based on VOCs, to define objects with early binding methods.

\                      Supports single inheritance.

\                             Version 0.7.0-FR

\                     Copyright (C) 2017 Manfred Mahlow

\        This is free software under the GNU General Public License v3.
\ ------------------------------------------------------------------------------
\ Please see the VOC-HOWTO-Classes-x.txt files how to create and use classes. 

\ Glossary:

\ class ( "name" -- )  Create a vocabulary prefix (see vocs.txt) to be used as
\                      a class context. Inherits from class-root.

\ <class> class ( "name" -- )  Create a class that inherits from (extends) the
\                              given <class>.

\ <class> definitions ( -- )  Make <class> the current compilation context.

\ __ivar ( -- ivsys 0|inherited-size ) Begin or extend an instance definition
\                                      in the current class compilation context.

\ __seal ( ivsys size -- )  Terminate an instance definition in the current 
\                           class compilation context. Creates u/i.

\ __ ( -- )  Make the current class compilation context the actual search order.

\ <class> ivar ( "name" ivsys n1 -- ivsys n2 )  Create an object of <class>
\                                               inside an instance definition.

\ <class> object ( "name" -- )  Create an object of <class>.

\ <class> u/i ( -- u )  Return the instance data size of <class>.

\ ------------------------------------------------------------------------------

#require vocs.txt
#require abort
#require struct.txt

  inside 

  voc-root set-current

: definitions
  [ voc-root set-context ] definitions [ inside ] 2 _vcm_ !
; 


inside definitions hex

\ Abort with error message if not in class compile mode.
: _?ccm_ ( -- )
  _vcm_ @ 2 <> if ." class compile mode missing" abort then
;


#1234567890 constant ivr-sys

\ Abort with error message if called with an invald ivr-sys.
: ?ivr-sys ( magic n -- magic n )
  over ivr-sys - if ." invalid instance size" abort exit then ;


forth definitions inside

\ Begin or extend an instance definition in a class definition.
: __ivar ( -- magic 0|inherited-size ) 
  _?ccm_ ivr-sys current @ dup _csr_ ! 
  s" u/i" 2dup 4 pick search-in-wordlist
  if ." instance is sealed" abort exit then
  evaluate nip
;


\ Terminate an instance definition in a class definition.
: __seal ( magic size -- )
  _?ccm_ ?ivr-sys s" constant u/i" evaluate drop
;


\ Make the current class compilation context the actual search context.
: __ ( -- )
  _?ccm_ get-current _csr_ ! immediate
;


inside definitions

\ Assign the actual class context to the next created word and return the 
\ instance size of the class on the stack.
: class-item ( -- u/i )
  voc-context @ _csr_ ! s" u/i" evaluate  \ get the instance size
  [ voc-root set-context ] casted [ inside ]
;


\ A root VOC for all classes.
voc class-root  class-root definitions

0 constant u/i   \ class-root has no instance data defined

\ Return an objects data address.
: _addr_ ( oid -- addr )
\  postpone .. immediate ;                    \ MM-170725
  class-root ['] .. execute immediate
;

\ Create an instance variable in the current class definition.
: ivar ( "name" magic n1 -- magic n2 )
  ?ivr-sys class-item +field
;

\ Create an instance of a class.
: object ( "name" -- )
  class-item buffer:
;

\ Create a class that inherits from (extends) the actual class context. 
: class ( "name" -- )
 [ voc-root set-context ] voc
;

  forth definitions  inside

\ Create a class that only inherits from (extends) class-root.
: class ( "name" -- )
  [ class-root .. voc-context @ literal, ] ( wid of class-root ) voc-extend ;
   
  forth

\index  class  object  compiletoram  compiletoflash

\ ------------------------------------------------------------------------------
\ Last Revision: MM-170729 Code review, some comments changed
\                          new version 0.7.0-FR
\                MM-170725 _addr_ redefined, failed with RA 2.3.x
\                          new version 0.6.4-FR
\\
\                MM-170712 definitions redefined, _ccm_ deleted
\                MM-170709 casted-u/i --> class-item and moved to inside
\                          new version 0.6.3
\                MM-170705 quit replaced with abort , obj --> object 
\                          _addr_ added , _size_ --> u/i
\                MM-170704 code review, code partly refactored, comments added
\                MM-170701 oop.txt splittet in vocs.txt and class.txt
\                          code partly rewritten

