#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""Forth include preprocessor

This module scans file for include directive and inserts all desired files into the output file which can be processed later ...
"""

import os.path
import sys
import argparse

# if the include-file is not in the current folder, check in all folders in the list
include_path = ['.']

# some additional info?
verbose = None

# main function - copies line by line input file to output file except if 'include' is founded.
# in this case the whole file is inserted.
def process_file(fname, uploading_directive):
    # no name - then stdin
    if fname == None:
        buff=sys.stdin.read()
    else:
        # read the file
        with open(fname) as fd:
            buff = fd.read()
            fd.close()
    dest = r''
    # definition of the keyword
    for si in uploading_directive:
        s = si.lower()
        sp = len(s)
        lines = buff.split('\n')
        for ln in lines:
            # discard spaces
            x = ln.strip()
            y = x.split()
            # keyword, separator (space), filename.
            # if filename exists ...
            if len(y) > 1 and len(y[1]) > 0:
                # check for include keyword, ignore case
                if s == y[0].lower():
                    # we have a winner, get it and remove spaces
                    nname = y[1].strip() 
                    for folder in include_path:
                        # check in all folders
                        filepath = os.path.join(folder, nname)
                        if os.path.isfile(filepath) :
                            break
                    else:
                        print >> sys.stderr, "?File not found:", nname
                    # include the whole file
                    ln = '\\ inc. {}\n'.format(nname)
                    ln += process_file(filepath)
                    ln += '\\ end of ' + nname
            # append the line / file
            dest += ln + '\n'
    return dest

if __name__ == '__main__':
    print 'Forth preprocessor '
    parser = argparse.ArgumentParser(os.path.basename(sys.argv[0]))
    parser.add_argument('filename', nargs='?')
    parser.add_argument('-I', '--include', action='append')
    parser.add_argument('-u', '--uploading-directive', action='append', help="define a uploading directive(s)", default=['include'])
    parser.add_argument('-o', '--output', action='store', type=argparse.FileType('w'), default=sys.stdout, help='target file')
    parser.add_argument('-v', "--verbose", help="increase output verbosity", action="store_true")

    args = parser.parse_args()
    verbose = args.verbose
    if args.include : 
        include_path += (args.include)
    if verbose: 
        print >> sys.stderr, 'include_path =', ', '.join(include_path)
        print >> sys.stderr, '{}: {}'.format(os.path.basename(sys.argv[0]), args.filename)
    filename = args.filename
    if filename is not None and filename is '-':
        filename = None
    print >> args.output, process_file(filename, args.uploading_directive)

# vim: tabstop=4 shiftwidth=4 expandtab:
