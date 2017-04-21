TERMPORT ?= /dev/ttyUSB0
uploader ?= cat #$(shell pwd)/me4up -d $(TERMPORT)
#uploader ?= ascii-xfr -s -c 3 -l 10

serial:
	picocom --send-cmd "$(uploader)" --omap delbs --emap bsdel -l --omap delbs --emap bsdel --imap lfcrlf -b 115200 -f h $(TERMPORT)

# https://aur.archlinux.org/packages/teensy-loader-cli-git/
# press button then run: make install
install:
	teensy-loader-cli -mmcu=mk20dx256 -wv mecrisp-stellaris-mk20dx256.hex

%.txt:
	$(uploader) $^ $@
