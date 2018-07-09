#!/bin/bash

xsltproc extract-with-bitfields.xsl $@ | sed -e 's/0x/\$/gi' 
