\ Words to allow us to create structures

\ Start a structure definition, returning zero as the initial offset.
0 constant [struct     \ ( -- 0 ) 

\ When defining a structure, a field of size n starts
\ at the given offset, returning the next offset. At
\ run time, the offset is added to the base address.
: field	    	       \ ( offset n -- offset+n ) ; ( addr -- addr+offset )
 <builds over , +      \ write offset to parameter field and update to new offset
 does> @ +	       \ add offset to address
;

\ End a structure definition by naming it.
: struct] ( offset -- ) ( -- size ) constant ;
