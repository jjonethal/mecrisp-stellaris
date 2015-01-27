\ Fault handler -- determine what unhandled interrupt occurred

: .fault ipsr ." Unhandled fault #" . CR ;

