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
fileName    = arg[2]
local e, p  = rs232.open(port_name)
if e ~= rs232.RS232_ERR_NOERROR then
	-- handle error
	io.output():write(string.format("can't open serial port '%s', error: '%s'\n",
			port_name, rs232.error_tostring(e)))
	return
end

-- set port settings
assert(p:set_baud_rate(rs232.RS232_BAUD_115200) == rs232.RS232_ERR_NOERROR)
assert(p:set_data_bits(rs232.RS232_DATA_8) == rs232.RS232_ERR_NOERROR)
assert(p:set_parity(rs232.RS232_PARITY_NONE) == rs232.RS232_ERR_NOERROR)
assert(p:set_stop_bits(rs232.RS232_STOP_1) == rs232.RS232_ERR_NOERROR)
assert(p:set_flow_control(rs232.RS232_FLOW_OFF)  == rs232.RS232_ERR_NOERROR)

local port=p
local timeout=100

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
		if data_read and data_read ~= "\n" and data_read ~= "\r" then
			res = res .. data_read
		end
	until data_read == nil or data_read == "\n" or data_read == "\r"
	return res
end

requiredFiles={}

function baseName(fname)
	return string.match(fname,"[^\\]*$")
end

function pathName(fname)
	print("pathName",fname, string.match(fname,"(.*\\)[^\\]*$"))
	return string.match(fname,"(.*\\)[^\\]*$")
end

function isAbsolutePath(fname)
	local res=string.match(fname,"^[A-Za-z]:\\") or string.match(fname,"^\\")
	return res ~=nil and res ~= ""
end

function required(currentFileName,requiredFileName,include)
	if not isAbsolutePath(requiredFileName) then
		requiredFileName = pathName(currentFileName) .. requiredFileName
	end
	if not requiredFiles[requiredFileName] or include == true then
		requiredFiles[requiredFileName]=true
		sendFile(requiredFileName)
	end
end

function preprocess(currentFileName,l)
	local requiredFileName = string.match(l,"require%s+(%S+)")
	if requiredFileName then
		required(currentFileName,requiredFileName)
		return true
	end
	local includeFileName = string.match(l,"include%s+(%S+)")
	if includeFileName then
		required(currentFileName,includeFileName,true)
		return true
	end
end

function sendFile(fileName)
	local i=0
	for l in io.lines(fileName) do
		i=i+1
		-- print("read",l)
		l =string.gsub(l,"(\\%s+.*)","")
		if not preprocess(fileName,l) then
			print(l)
			p:write(l)
			p:write("\n")
			local l = readLine(p, timeout)
			print(l)
			if l:match("not found%.$") then
				print("error in file",fileName,i)
				return
			elseif not l:match("ok%.$") then
				print("Note!")				
			end
		end
	end
end

fileName = fileName or [[C:\Users\jeanjo\work\forth\mecrisp-stellaris\stm32f746-ra\qspi6.fth]]
sendFile(fileName)
