: test-tx
\ SI4432-init
s" Sertolovo" SI4432-Transmit
cr ." The end!"
;

: info
cr ." recivied: " SI4432_status @ hex.
cr 2 si4432> ." status:" hex.
cr si4432-rxbuf si4432_pkt_len @ type
s" Slave ok!" SI4432-Transmit cr ." send" 
 \ si4432-rdintst drop cr ." trans:" hex. 
 ;

: test-rx
lcd-init clrscn
SI4432-start
begin 
200 ms

\ SI4432_status @ SI4432_RF_PACKET_RECEIVED and
nIRQ?
si4432-rdintst drop SI4432_RF_PACKET_RECEIVED and and
if  
SI4432-Packet-Recived
info
then

$26 si4432> 0 2 setxy n>s lcd-type
key? if
key [char] s =
if
s" Kent&Fix" SI4432-Transmit cr SI4432_status @ hex. 0
else 
true
then
else false then
SI4432-Receive
until
;
