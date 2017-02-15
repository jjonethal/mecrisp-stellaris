-- crc.lua
local b      = require "bit"
local band   = b.band
local lshift = b.lshift
local bxor   = b.bxor

--[[
   /* update CRC */
    unsigned short
    updcrc(c, crc)
    register c;
    register unsigned crc;
    {
            register count;

            for (count=8; --count>=0;) {
                    if (crc & 0x8000) {
                            crc <<= 1;
                            crc += (((c<<=1) & 0400)  !=  0);
                            crc ^= 0x1021;
                    }
                    else {
                            crc <<= 1;
                            crc += (((c<<=1) & 0400)  !=  0);
                    }
            }
            return crc;
    }

]]

local function printf(fmt,...)
	print(string.format(fmt,...))
end

function updateCrc( crc, c)
	for i = 0,7 do
		if 0~= band(crc,0x8000) then
--			crc <<= 1;
			crc = crc + crc
--			crc += (((c<<=1) & 0400)  !=  0);
			c = c + c
			if 0 ~= band(c, 0x100) then crc = crc + 1 end
--			crc ^= 0x1021;
			crc = bxor(crc, 0x1021)
			printf("CRC    xor 0x%04X", crc)
		else
--			crc <<= 1;
			crc = crc + crc
--			crc += (((c<<=1) & 0400)  !=  0);
			c = c + c
			if 0 ~= band(c, 0x100) then	crc = crc + 1 end
			printf("CRC no xor 0x%04X", crc)
		end
	end
	crc = band(crc, 0xFFFF)
	return crc
end

