\ Program Name: 1b.fs  for Mecrisp-Stellaris by Matthias Koch and licensed under the GPL
\ Copyright 2019 t.porter <terry@tjporter.com.au> and licensed under the BSD license.
\ This program must be loaded before memmap.fs as it provided the pretty printing legend for generic 32 bit prints
\ Also included is bin. which prints the binary form of a number with no spaces between numbers for easy copy and pasting puroses

compiletoflash


: 1b. ( u -- ) cr \ Label 1 bit generic groups
." 3|3|2|2|2|2|2|2|2|2|2|2|1|1|1|1|1|1|1|1|1|1|" cr
." 1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0 " cr
@ binary b32loop. decimal cr cr ;


: bin. cr
." 3322222222221111111111" cr
." 10987654321098765432109876543210 " cr
binary b32sloop. decimal ;



