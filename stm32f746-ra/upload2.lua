-- upload2.lua

WINSUBST={
	_In_     = "",
	WINAPI   = "__stdcall",
	_Out_    = "",
	_In_opt_ = "",
}

local function ffcdfilt(s)
	local sfilt=string.gsub(s,"([%w_]+)",WINSUBST)
	local n=0
	-- print(select(1,sfilt:gsub("([^\n]*)\n",function(l) n=n+1 return n .." ".. l .. "\n" end)))
	return ffi.cdef(sfilt)
end

if jit.arch == "x64" then
	ffcdfilt[[
		typedef __int64 LONG_PTR;
		typedef unsigned __int64 UINT_PTR;
		typedef __int64 LONGLONG;
	]]
	print("jit.arch x64",jit.arch)
else
	ffcdfilt[[
		typedef long LONG_PTR;
		typedef unsigned int UINT_PTR;
		typedef __int64 LONGLONG;
	]]
	print("jit.arch x32",jit.arch)
end

ffcdfilt[[
	typedef  const char *LPCSTR;
	typedef wchar_t WCHAR;
	typedef WCHAR *LPWSTR;
	typedef const WCHAR *LPCWSTR;
]]

if UNICODE then
	ffcdfilt[[
		 typedef LPCWSTR LPCTSTR;
	]]
else
	ffcdfilt[[
		typedef LPCSTR LPCTSTR;
	]]
end


ffcdfilt[[
typedef int BOOL;
typedef void VOID;
typedef unsigned short WORD;
typedef unsigned long DWORD;
typedef long LONG;
typedef unsigned int UINT;
typedef wchar_t WCHAR;
typedef WCHAR *LPWSTR;
typedef const WCHAR *LPCWSTR;
typedef void * PVOID;
typedef  const char *LPCSTR;
typedef PVOID HANDLE;
typedef HANDLE HBRUSH;
typedef HANDLE HICON;
typedef HICON  HCURSOR;
typedef HANDLE HINSTANCE;
typedef HANDLE HMENU;
typedef HINSTANCE HMODULE;
typedef HANDLE HWND;
typedef void *LPVOID;
typedef WORD ATOM;
typedef LONG_PTR LRESULT;
typedef UINT_PTR WPARAM;
typedef LONG_PTR LPARAM;

typedef struct _OVERLAPPED {
  ULONG_PTR Internal;
  ULONG_PTR InternalHigh;
  union {
    struct {
      DWORD Offset;
      DWORD OffsetHigh;
    };
    PVOID  Pointer;
  };
  HANDLE    hEvent;
} OVERLAPPED, *LPOVERLAPPED;


DWORD WINAPI MsgWaitForMultipleObjects(
  _In_       DWORD  nCount,
  _In_ const HANDLE *pHandles,
  _In_       BOOL   bWaitAll,
  _In_       DWORD  dwMilliseconds,
  _In_       DWORD  dwWakeMask
);

HANDLE WINAPI CreateEvent(
  _In_opt_ LPSECURITY_ATTRIBUTES lpEventAttributes,
  _In_     BOOL                  bManualReset,
  _In_     BOOL                  bInitialState,
  _In_opt_ LPCTSTR               lpName
);

BOOL WINAPI ResetEvent(
  _In_ HANDLE hEvent
);

BOOL WINAPI CloseHandle(
  _In_ HANDLE hObject
);

BOOL WINAPI GetOverlappedResult(
  _In_  HANDLE       hFile,
  _In_  LPOVERLAPPED lpOverlapped,
  _Out_ LPDWORD      lpNumberOfBytesTransferred,
  _In_  BOOL         bWait
);

BOOL WINAPI WaitCommEvent(
  _In_  HANDLE       hFile,
  _Out_ LPDWORD      lpEvtMask,
  _In_  LPOVERLAPPED lpOverlapped
);

]]

EV_BREAK = 0x0040
EV_CTS   = 0x0008
EV_DSR   = 0x0010
EV_ERR   = 0x0080
EV_RING  = 0x0100
EV_RLSD  = 0x0020

--- cast value to ulong
local function ulong(n)
	return ffi.cast("ULONG",n)
end
--- cast value to ulong
local function uptr(n)
	return ffi.cast("UINT_PTR",n)
end


local observerHandles=ffi.new("HANDLE[10]")
local observerHandlers={} -- handler indexed by handle
local numObservers = 0

--- remove an existing handler 
local function removeHandlerFunktion(handle)
	for i=0,numObservers-1 do
		if uptr(observerHandles[i]) == uptr(handle) then
			for j=i, numObservers-2 do
				observerHandles[j] = observerHandles[j+1]
			end
			if numObservers > 0 then
				numObservers = numObservers - 1
			end
			observerHandlers[handle]=nil
			return true
		end
	end
end

--- add a handle with corresponding handler function
-- when fct is nil remove the handle
local function addHandlerFunction(handle,fct)
	if fct == nil then
		return removeHandlerFunktion(handle)
	end
	local ulHandle = uptr(handle)
	for i=0,numObservers-1 do
		if uptr(observerHandles[i]) == ulHandle then
			observerHandlers[ulHandle]=fct
			return true
		end
	end
	observerHandles[numObservers]=handle
	observerHandlers[ulHandle] = fct
	numObservers = numObservers + 1	
end

function messageLoop()
	while true
		local n = ffi.C.MsgWaitForMultipleObjects(numObservers,observerHandles,false,10,QS_ALLINPUT)
		if n == WAIT_TIMEOUT then
			-- print("timeout")
		elseif n >= WAIT_OBJECT_0 and n < WAIT_OBJECT_0 + nObserv then
			print("handle object")
			local nwo = n-WAIT_OBJECT_0
			local handle = observerHandles[nwo]
			local handler=observerHandlers[uptr(handle)]
			if handler and type(handler) == "function" then
				handler(handle)
			end
		elseif n == nObserv + WAIT_OBJECT_0 then
			-- print("handleMessage")
			-- local newMessage = false
		end
	end
end

txSerReady=true

function rxTcp()
	while true do
		local n = txBuffer:free()
		local data=tcpClient:read(n)
		txBuffer:write(data)
	end
end

function rxSer()
	while true do
		local data = serialPort:read()
		if scanOk(data) then
			txSerReady = true
		end
	end
end

function txSer()
	while true do
		if txSerReady then
			txBuffer:()
		end
	end
end

function txTcp()
end