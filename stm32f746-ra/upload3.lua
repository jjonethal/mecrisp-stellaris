-- upload3.lua
local socket=require"socket"
local rs232=require"luars232"

local server=socket.bind("*",0)

function tcpserver()
	while true do
		local client=server:accept()
		
	end
end

function open(port)
	local e,p = rs232.open(port)
	assert(e==rs232.RS232_ERR_NOERROR
		,("error: %scannot open port %s "):format(rs232.error_tostring(e), port))
	assert(p:set_baud_rate(rs232.RS232_BAUD_115200) == rs232.RS232_ERR_NOERROR)
	assert(p:set_data_bits(rs232.RS232_DATA_8) == rs232.RS232_ERR_NOERROR)
	assert(p:set_parity(rs232.RS232_PARITY_NONE) == rs232.RS232_ERR_NOERROR)
	assert(p:set_stop_bits(rs232.RS232_STOP_1) == rs232.RS232_ERR_NOERROR)
	assert(p:set_flow_control(rs232.RS232_FLOW_OFF)  == rs232.RS232_ERR_NOERROR)
	return p
end

function okFound()
end

scanners={
	{s="ok.",pos=1,f=okFound,},
}
function scan(data)
	for i,scanner in ipairs(scanners) do
		for i=1,#data do
			if data:sub(i,i+1) == scanner.s:sub(scanner.pos,scanner.pos+1) then
				scanner.pos = scanner.pos + 1
				if scanner.pos > #scanner.s then
					scanner.pos=1
					scanner.f(scanner.s)
				end
			end
		end
	end
end
local err,data,size=p:read(100,0)

function uploadFile(fname)
	for l in io.lines(fname) do
		p:write(l)
		p:write("\n")
	
	end
end