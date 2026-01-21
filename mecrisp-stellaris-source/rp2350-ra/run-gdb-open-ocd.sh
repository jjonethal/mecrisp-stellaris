#!/bin/bash
openocd -f openocd.cfg > openocd.log 2>&1 &
OCPID=$!
trap "kill $OCPID" EXIT
tail -n +1 openocd.log | grep -m 1 "Listening on port 3333" --line-buffered
gdb-multiarch $1 -ex "target extended-remote :3333" -ex "load" -ex "monitor reset halt" -ex "tui new-layout split1 { -horizontal src 1 asm 1 regs 1} 1 cmd 1 " -ex "layout split1" -ex "break Reset" -ex "continue" -ex "focus cmd"
kill $OCPID
