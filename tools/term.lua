-- Copyright Jean Jonethal 2017
--
-- This program is free software: you can redistribute it and/or modify
-- it under the terms of the GNU General Public License as published by
-- the Free Software Foundation, either version 3 of the License, or
-- (at your option) any later version.
--
-- This program is distributed in the hope that it will be useful,
-- but WITHOUT ANY WARRANTY; without even the implied warranty of
-- MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
-- GNU General Public License for more details.
--
-- You should have received a copy of the GNU General Public License
-- along with this program.  If not, see <http://www.gnu.org/licenses/>.

local rs232=require("luars232")

port_name   = arg[1] or "COM4"
local e, p  = rs232.open(port_name)
if e ~= rs232.RS232_ERR_NOERROR then
	-- handle error
	out:write(string.format("can't open serial port '%s', error: '%s'\n",
			port_name, rs232.error_tostring(e)))
	return
end

-- set port settings
assert(p:set_baud_rate(rs232.RS232_BAUD_115200) == rs232.RS232_ERR_NOERROR)
assert(p:set_data_bits(rs232.RS232_DATA_8) == rs232.RS232_ERR_NOERROR)
assert(p:set_parity(rs232.RS232_PARITY_NONE) == rs232.RS232_ERR_NOERROR)
assert(p:set_stop_bits(rs232.RS232_STOP_1) == rs232.RS232_ERR_NOERROR)
assert(p:set_flow_control(rs232.RS232_FLOW_OFF)  == rs232.RS232_ERR_NOERROR)


--- wait for answer from target and checks for detection strings
--  @param p rs232 port to get response from.
--  @param timeout in milliseconds to wait for characters.
--  @param detectors is table with detectors to scan response with.
--  @return response from target and number of the detector that matched.
function waitResponse(p, timeout, detectors)
  local res = ""
  local read_len = 1
  local det = 0
  repeat 
    local err, data_read, size = p:read(read_len, timeout)
    assert(e == rs232.RS232_ERR_NOERROR)
    if data_read ~= nil then
      res = res .. data_read
      for i,detData in ipairs(detectors) do
        local df = detData.detect or detString -- fallback detector function
        if df(detData, data_read) then
          det = i
          break
        end
      end
    end
  until (data_read == nil) or (det ~= 0)
  return res,det
end

function readLine(port,timeout)
	local res=""
	repeat 
		local err, data_read, size = port:read(1,timeout)
		assert(e == rs232.RS232_ERR_NOERROR)
		-- print("data_read",data_read)
		if data_read then
			res = res .. data_read
		end
	until data_read == nil or data_read == "\n" or data_read == "\r"
	return res
end

function sendFile(port, fileName,timeout)
	for l in io.lines(fileName) do
		print(l)
		p:write(l)
		p:write("\n")
		local l = readLine(p, timeout)
		print(l)
		if not l:match("ok%.") then
			print("error")
			return
		end
	end
end

fileName = [[C:\Users\jeanjo\work\forth\mecrisp-stellaris\stm32f746-ra\qspi6.fth]]
sendFile(p,fileName,1)
