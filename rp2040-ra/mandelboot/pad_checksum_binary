#!/usr/bin/env python3

import argparse
import binascii
import struct
import sys


def any_int(x):
    try:
        return int(x, 0)
    except:
        raise argparse.ArgumentTypeError("expected an integer, not '{!r}'".format(x))


def bitrev(x, width):
    return int("{:0{w}b}".format(x, w=width)[::-1], 2)


parser = argparse.ArgumentParser()
parser.add_argument("ifile", help="Input file (binary)")
parser.add_argument("ofile", help="Output file (assembly)")
parser.add_argument("-p", "--pad", help="Padded size (bytes), including 4-byte checksum, default 256",
                    type=any_int, default=256)
parser.add_argument("-s", "--seed", help="Checksum seed value, default 0",
                    type=any_int, default=0)
args = parser.parse_args()

try:
    idata = open(args.ifile, "rb").read()
except:
    sys.exit("Could not open input file '{}'".format(args.ifile))

if len(idata) > args.pad - 4:
    sys.exit("Input file size ({} bytes) too large for final size ({} bytes)".format(len(idata), args.pad))

idata_padded = idata + bytes(args.pad - 4 - len(idata))

# Our bootrom CRC32 is slightly bass-ackward but it's best to work around for now (FIXME)
# 100% worth it to save two Thumb instructions
checksum = bitrev(
    (binascii.crc32(bytes(bitrev(b, 8) for b in idata_padded), args.seed ^ 0xffffffff) ^ 0xffffffff) & 0xffffffff, 32)
odata = idata_padded + struct.pack("<L", checksum)

try:
    fout = open(args.ofile, "wb");
    fout.write(odata);
    fout.close;

except:
    sys.exit("Could not open output file '{}'".format(args.ofile))
