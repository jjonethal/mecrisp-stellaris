#!/bin/bash
openocd -f openocd.cfg > openocd.log 2>&1 &
OCPID=$!
trap "kill $OCPID" EXIT
tail -n +1 openocd.log | grep -m 1 "Listening on port 3333" --line-buffered
gdb-multiarch $1 -ex "target extended-remote :3333"
kill $OCPID
