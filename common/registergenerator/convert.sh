#!/bin/bash

xsltproc extract-mecrisp.xsl $@ | sed -e 's/0x/\$/gi' 
