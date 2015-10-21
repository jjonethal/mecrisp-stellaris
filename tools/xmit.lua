-- file: xmit.lua
-- utility for mecrisp file transfer
-- all copyrights (c) 2015 by Jean Jonethal

local rs232 = require'luars232'
port_name   = "COM1"
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

-- detData1 = { str="ok.", pos=1 }
-- detData2 = { str="not found.", pos=1 }
-- detectors = { detData1, detData2 }

--- detect a string resets detData.pos to 1 on mismatch
--  @param detData table containing search string ans strt position { str="search", pos=1 }
--  @param c next character to check
--  @return true on match else false
function detString(detData, c)
  -- print(detData.str, detData.pos, detData.pos, string.sub(detData.str, detData.pos, detData.pos), c)
  -- print( #detData.str)
  if string.sub(detData.str, detData.pos, detData.pos) == c then
    detData.pos = detData.pos + 1
    if detData.pos > #detData.str then
      return true
    end
  else
    detData.pos = 1
  end
  return false
end

--- build detector table for string str using detectFunction
--  @param str search string for detector
--  @param detect opt. function to be used for detector, default is detString.
--  @return table { pos=1, str=str, detect=detString }
function detector(str, detectFunction)
  return {str = str, pos = 1, detect=detectFunction or detString}
end
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

--- perform detector test
function testDetectors()
  local timeout   = 100 -- milliseconds
  local detectors = {detector("ok."), detector("not found.") }
  -- write without timeout
  local err, len_written = p:write("words\n")
  assert(err == rs232.RS232_ERR_NOERROR)

  local res, det = waitResponse(p, timeout,detectors)
  print(res)
  assert(det == 1,"detection failed")

  local err, len_written = p:write("asdfasd\n")
  assert(err == rs232.RS232_ERR_NOERROR)

  local res, det = waitResponse(p, timeout,detectors)
  print(res)
  assert(det == 2,"detection failed")
end
testDetectors()
