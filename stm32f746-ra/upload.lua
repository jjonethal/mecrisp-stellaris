-- gui3.lua
local ffi=require"ffi"
local bit=require"bit"
local bor=bit.bor
local stdout=io.output()
local WINUSER_H=[[C:\MinGW\include\winuser.h]]
local IMM_H=[[C:\MinGW\include\imm.h]]

local DEBUG=true
UNICODE=true

function printf(fmt, ...)
	stdout:write(string.format(fmt,...))
end


WINSUBST={
	_In_     = "",
	WINAPI   = "__stdcall",
	_Out_    = "",
	_In_opt_ = "",
}

local max=math.max

function addIndex(t,id,n)
	n=tonumber(n)
	if t and id and n then
		-- print(id,n,t[id],t[n])
		t[id]=n t[n]=id
		t.maxlen=max(t.maxlen or 0,#id)
	end
end

allIndex={}

local function readAll(fn)
	local t = allIndex[fn]
	if t then
		return t
	end
	local f = io.open(fn)
	local h = f:read("*a")
	f:close()
	allIndex[fn]=h
	return h
end

--- create pattern for #define WM_xxx 123
function defBasPattern(s)
	return "#define%s+(" .. s .. "_[%w_]+)%s+(0?[xX]?[%x]*)"
end
WM_DEF=defBasPattern("WM")

-- parse defines #define XXXX 123 and create index
-- pattern creates 2 groups first is id and second is value
function parseDefines(h,pattern,idx)
	local wm=idx or {}
	string.gsub(h,pattern,
		function(id,num) addIndex(wm, id, num) end
	)
	return wm
end

-- write all keys with number values to file
local function exportDefs(idx, idx_id,fname)
	local names={}
	local l=0
	for k,v in pairs(idx) do
		if type(k) == "string" and type(v) == "number" then
			if l<#k then l=#k end
			names[#names+1]=k
			table.sort(names)
		end
	end
	local f=io.open(fname,"w")
	f:write("local ",idx_id," = {}\n")
	for _,k in ipairs(names) do
		f:write(idx_id,".",k,(" "):rep(l-#k)," = ",string.format("0x%08X",idx[k]),"\n")
	end
	f:write("return ",idx_id, "\n")
	f:close()
end

-- check if file is readable
local function fileExist(fname)
	local f=io.open(fname,"r")
	local exist = f~=nil
	if f then
		f:close()
	end
	return exist
end


-- create index of definitions from fname like #define WM_AAA 123 ...
-- @param fname header file to parse
-- @param basePattern of definition id e.g. "WM" for WM_*
function createBaseDefinitionIndex(headerData,basePattern,idx)
	return parseDefines(headerData,defBasPattern(basePattern),idx)
end

function parseWMNames()
	local h=readAll(WINUSER_H)
	local wm={}
	string.gsub(h,"#define%s+(WM_[%w_]+)%s+([x%x]*)",
		function(id,num) addIndex(wm, id, num) end
	)
	return wm
end
local WINDOWS_H
local function genAllWinDefs()
	if not WINDOWS_H then
		local f = io.popen([[cmd /c set path=c:\mingw\bin;%PATH% && gcc -E -dM -dI C:\MinGW\include\windows.h -include C:\MinGW\include\imm.h]])
		WINDOWS_H=f:read("*a")
		f:close()
	end
	return WINDOWS_H
end

function requireOpt(fname)
	if fileExist(fname ..".lua") then
		return require(fname)
	end
end

print("load All defs")

local wmAll = requireOpt("wmAll")
local bsAll = requireOpt("bsAll")
local wsAll = requireOpt("wsAll")
print("loaded All defs",wmAll,bsAll,wsAll)

-- local WM_INDEX=parseWMNames()
print("creating index")
local WM_INDEX,wm,bs,ws
if not wmAll then
	WM_INDEX = createBaseDefinitionIndex(readAll(WINUSER_H),"WM")
	WM_INDEX = createBaseDefinitionIndex(readAll(IMM_H),"WM",WM_INDEX)
	wm       = WM_INDEX
	wmAll    = createBaseDefinitionIndex(genAllWinDefs(),"WM")
else
	WM_INDEX,wm = wmAll,wmAll
end

bs       = bsAll or createBaseDefinitionIndex(readAll(WINUSER_H),"BS")
ws       = wsAll or createBaseDefinitionIndex(readAll(WINUSER_H),"WS")
print("created index")


--- count all items in table
local function countItems(t)
	local i=0
	for k,v in pairs(t) do
		i = i + 1
	end
	return i
end
print("num defines wmAll",countItems(wmAll))
print("num defines bs",countItems(bs))
print("num defines ws",countItems(ws))
print("num defines wm",countItems(wm))

--- export index table with string = number pairs
local function condExportIndexFile(idx, idxName, fname)
	if not fileExist(fname) then
		exportDefs(idx, idxName, fname)
	end
end

condExportIndexFile(wmAll,"wmAll","wmAll.lua")
condExportIndexFile(bs,   "bs",   "bsAll.lua")
condExportIndexFile(ws,   "ws",   "wsAll.lua")


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

typedef  LRESULT  (__stdcall *WNDPROC)(
  HWND   hwnd,
  UINT   uMsg,
  WPARAM wParam,
  LPARAM lParam
);


typedef struct tagWNDCLASSEX {
  UINT      cbSize;
  UINT      style;
  WNDPROC   lpfnWndProc;
  int       cbClsExtra;
  int       cbWndExtra;
  HINSTANCE hInstance;
  HICON     hIcon;
  HCURSOR   hCursor;
  HBRUSH    hbrBackground;
  LPCTSTR   lpszMenuName;
  LPCTSTR   lpszClassName;
  HICON     hIconSm;
} WNDCLASSEX, *PWNDCLASSEX;

typedef struct tagPOINT {
  LONG x;
  LONG y;
} POINT, *PPOINT;


typedef struct tagMSG {
  HWND   hwnd;
  UINT   message;
  WPARAM wParam;
  LPARAM lParam;
  DWORD  time;
  POINT  pt;
} MSG, *PMSG, *LPMSG;

typedef union _LARGE_INTEGER {
  struct {
    DWORD LowPart;
    LONG  HighPart;
  };
  struct {
    DWORD LowPart;
    LONG  HighPart;
  } u;
  LONGLONG QuadPart;
} LARGE_INTEGER, *PLARGE_INTEGER;

typedef struct _DCB {
  DWORD DCBlength;
  DWORD BaudRate;
  DWORD fBinary  :1;
  DWORD fParity  :1;
  DWORD fOutxCtsFlow  :1;
  DWORD fOutxDsrFlow  :1;
  DWORD fDtrControl  :2;
  DWORD fDsrSensitivity  :1;
  DWORD fTXContinueOnXoff  :1;
  DWORD fOutX  :1;
  DWORD fInX  :1;
  DWORD fErrorChar  :1;
  DWORD fNull  :1;
  DWORD fRtsControl  :2;
  DWORD fAbortOnError  :1;
  DWORD fDummy2  :17;
  WORD  wReserved;
  WORD  XonLim;
  WORD  XoffLim;
  BYTE  ByteSize;
  BYTE  Parity;
  BYTE  StopBits;
  char  XonChar;
  char  XoffChar;
  char  ErrorChar;
  char  EofChar;
  char  EvtChar;
  WORD  wReserved1;
} DCB, *LPDCB;


ATOM __stdcall RegisterClassExA(
  const WNDCLASSEX *lpwcx
);
ATOM __stdcall RegisterClassExW(
  const WNDCLASSEX *lpwcx
);



HWND __stdcall CreateWindowW(
  LPCTSTR   lpClassName,
  LPCTSTR   lpWindowName,
  DWORD     dwStyle,
  int       x,
  int       y,
  int       nWidth,
  int       nHeight,
  HWND      hWndParent,
  HMENU     hMenu,
  HINSTANCE hInstance,
  LPVOID    lpParam
);

HWND __stdcall CreateWindowA(
  LPCTSTR   lpClassName,
  LPCTSTR   lpWindowName,
  DWORD     dwStyle,
  int       x,
  int       y,
  int       nWidth,
  int       nHeight,
  HWND      hWndParent,
  HMENU     hMenu,
  HINSTANCE hInstance,
  LPVOID    lpParam
);

HWND __stdcall CreateWindowExW(
	DWORD     dwExStyle,
	LPCTSTR   lpClassName,
	LPCTSTR   lpWindowName,
	DWORD     dwStyle,
	int       x,
	int       y,
	int       nWidth,
	int       nHeight,
	HWND      hWndParent,
	HMENU     hMenu,
	HINSTANCE hInstance,
	LPVOID    lpParam
);

HWND __stdcall CreateWindowExA(
	DWORD     dwExStyle,
	LPCTSTR   lpClassName,
	LPCTSTR   lpWindowName,
	DWORD     dwStyle,
	int       x,
	int       y,
	int       nWidth,
	int       nHeight,
	HWND      hWndParent,
	HMENU     hMenu,
	HINSTANCE hInstance,
	LPVOID    lpParam
);



HMODULE __stdcall GetModuleHandleW(
   LPCTSTR lpModuleName
);
HMODULE __stdcall GetModuleHandleA(
   LPCTSTR lpModuleName
);
VOID __stdcall PostQuitMessage(
  int nExitCode
);

LRESULT __stdcall DefWindowProcW(
   HWND   hWnd,
   UINT   Msg,
   WPARAM wParam,
   LPARAM lParam
);

HICON __stdcall LoadIconW(
   HINSTANCE hInstance,
   LPCTSTR   lpIconName
);

HICON __stdcall LoadIconA(
   HINSTANCE hInstance,
   LPCTSTR   lpIconName
);

HCURSOR __stdcall LoadCursorW(
	HINSTANCE hInstance,
	LPCTSTR   lpCursorName
);
HCURSOR __stdcall LoadCursorA(
	HINSTANCE hInstance,
	LPCTSTR   lpCursorName
);

BOOL __stdcall ShowWindow(
	HWND hWnd,
	int  nCmdShow
);

BOOL __stdcall GetMessageW(
	LPMSG lpMsg,
	HWND  hWnd,
	UINT  wMsgFilterMin,
	UINT  wMsgFilterMax
);

BOOL __stdcall TranslateMessage(
	const MSG *lpMsg
);

LRESULT WINAPI DispatchMessageW(
	_In_ const MSG *lpmsg
);

LRESULT WINAPI SendMessageW(
  _In_ HWND   hWnd,
  _In_ UINT   Msg,
  _In_ WPARAM wParam,
  _In_ LPARAM lParam
);

BOOL WINAPI MoveWindow(
  _In_ HWND hWnd,
  _In_ int  X,
  _In_ int  Y,
  _In_ int  nWidth,
  _In_ int  nHeight,
  _In_ BOOL bRepaint
);

BOOL WINAPI QueryPerformanceCounter(
  _Out_ LARGE_INTEGER *lpPerformanceCount
);

DWORD WINAPI MsgWaitForMultipleObjects(
  _In_       DWORD  nCount,
  _In_ const HANDLE *pHandles,
  _In_       BOOL   bWaitAll,
  _In_       DWORD  dwMilliseconds,
  _In_       DWORD  dwWakeMask
);

BOOL WINAPI PeekMessageW(
  _Out_    LPMSG lpMsg,
  _In_opt_ HWND  hWnd,
  _In_     UINT  wMsgFilterMin,
  _In_     UINT  wMsgFilterMax,
  _In_     UINT  wRemoveMsg
);

BOOL WINAPI AppendMenuW(
  _In_     HMENU    hMenu,
  _In_     UINT     uFlags,
  _In_     UINT_PTR uIDNewItem,
  _In_opt_ LPCTSTR  lpNewItem
);

]]

function MAKEINTRESOURCE(i)
	if type(i) == 'number' then
		return ffi.cast('LPCTSTR', ffi.cast('WORD', i))
	end
	return i
end


COLOR_WINDOW    = 5

CS_DBLCLKS = 0x0008
CS_HREDRAW = 0x0002
CS_VREDRAW = 0x0001

CW_USEDEFAULT = 0x80000000 --if used for x, then y must be a SW_* flag

IDC_ARROW       = MAKEINTRESOURCE(0x7F00)
IDI_APPLICATION = MAKEINTRESOURCE(0x7F00)

WAIT_OBJECT_0 = 0
WAIT_ABANDONED_0 = 128
WAIT_TIMEOUT = 258
WAIT_FAILED = 0xFFFFFFFF

PM_REMOVE = 1
QS_ALLINPUT = 255


WS_CAPTION          = 0x00C00000
WS_MAXIMIZEBOX      = 0x00010000
WS_MINIMIZEBOX      = 0x00020000
WS_OVERLAPPED       = 0x00000000
WS_SYSMENU          = 0x00080000
WS_THICKFRAME       = 0x00040000


WS_OVERLAPPEDWINDOW = bor(WS_OVERLAPPED,WS_CAPTION,WS_SYSMENU,WS_THICKFRAME,WS_MINIMIZEBOX,WS_MAXIMIZEBOX)

WM_DESTROY   = 0x0002
WM_QUIT      = 0x0012


SW_SHOW = 5
SW_SHOWDEFAULT=10

function h8(n)
	return ("0x%08X"):format(tonumber(n))
end

local lpPerformanceCount = ffi.new("LARGE_INTEGER")
local function QueryPerformanceCounter()
	local res = ffi.C.QueryPerformanceCounter(lpPerformanceCount)
	if res ~= 0 then
		-- return tonumber(lpPerformanceCount.QuadPart)
		return lpPerformanceCount.QuadPart
	end
end

--- convert ascii string to WCHAR array
local function wc(s)
	local wstr=ffi.new("WCHAR[?]",#s+1,string.byte(s,1,#s))
	return wstr
end

--- retrieve the module handle
local function getInstance()
	local hInstance = ffi.C.GetModuleHandleW(ffi.cast("LPCTSTR",nil))
	return hInstance
end

function CreateWindow(hwndParent, hinstance, wcClass, wcTitle, style,x,y,w,h,menu)
	local hWnd = ffi.C.CreateWindowExW(
	0,
	wcClass,             -- name of window class
	wcTitle,             -- title-bar string
	style,               -- Button styles
	x,                   -- default horizontal position
	y,                   -- default vertical position
	w,                   -- default width
	h,                   -- default height
	hwndParent,          -- no owner window
	menu  ,              -- use class menu
	hinstance,           -- handle to application instance
	nil);                -- no window-creation data
	return hWnd
end


function setIndex(t,i)
	local mt = getmetatable(t) or {}
	mt.__index=i
	setmetatable(t,mt)
end

-- The Window class
Window={}
function Window.new(hwndParent, hinstance, wcClass, wcTitle, style,x,y,w,h,menu)
	local w={}
	setIndex(w,Window)
	w.hWnd = CreateWindow(hwndParent, hinstance, wcClass, wcTitle, style,x,y,w,h,menu)
	w.hwndParent = hwndParent
	w.hinstance = hinstance
	return w
end

function Window:move(x,y,w,h,bRepaint)
	return ffi.C.MoveWindow(self.hWnd, x, y, w, h, bRepaint)
end

--- the button class
Button={}
setIndex(Button,Window)
function Button.new(hinstance, hwndParent,x,y,w,h,sBtnLabel,btnStyle,action)
	local t=Window.new(hinstance, hwndParent, wc("BUTTON"),sBtnLabel,btnStyle,x,y,w,h,action)
	setIndex(t,Button)
end

function on_destroy(hwnd,uMsg, wParam, lParam) 
	print("\ndestroying window\n")
	ffi.C.PostQuitMessage(0)
	return 0
end

local handlers={}
handlers[WM_DESTROY] = ffi.cast("WNDPROC", on_destroy)
-- handlers[wm.WM_CREATE]  = ffi.cast("WNDPROC", on_create)


msg_fmt = "wndProc %-" .. WM_INDEX.maxlen .. "s  m:%s wp:%s lp:%s\n"
print("WM_INDEX",WM_INDEX)
function windowProc(hwnd,uMsg, wParam, lParam)
	printf(msg_fmt,WM_INDEX[uMsg] or "",h8(uMsg),h8(wParam),h8(ffi.cast("UINT",lParam)))
	local handler = handlers[uMsg]
	if handler then
		-- print("handler",handler)
		return handler( hwnd, uMsg, wParam, lParam )
	end
	-- print("ffi.C.DefWindowProc")
	io.output():flush()
	return ffi.C.DefWindowProcW(hwnd,uMsg, wParam, lParam)
end

--- cast value to ulong
local function ulong(n)
	return ffi.cast("ULONG",n)
end
--- cast value to ulong
local function uptr(n)
	return ffi.cast("UINT_PTR",n)
end




jit.off(windowProc)
WindowProcedure = ffi.cast("WNDPROC", windowProc)

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

local function messageLoop()
	local msg = ffi.new("MSG");
	local running = true
	while running do
		while( ffi.C.PeekMessageW( msg, nil, 0, 0, PM_REMOVE ) ~= 0) do
			-- print("MSG",msg)
			ffi.C.TranslateMessage(msg) 
			ffi.C.DispatchMessageW(msg)
			if msg.message == WM_QUIT then
				print("WM_QUIT","bye bye")
				running = false
			end
		end
		local nObserv=numObservers
		local n = ffi.C.MsgWaitForMultipleObjects(numObservers,observerHandles,false,10,QS_ALLINPUT)
		if n == WAIT_TIMEOUT then
			-- print("timeout")
		elseif n >= WAIT_OBJECT_0 and n < WAIT_OBJECT_0 + nObserv then
			print("handle object")
			local nwo = n-WAIT_OBJECT_0
			local h = observerHandlers[nwo]
			if h and type(h) == "function" then
				h(nwo, observerHandles)
			end
		elseif n == nObserv + WAIT_OBJECT_0 then
			-- print("handleMessage")
			-- local newMessage = false
		end
	end
end


wcx=ffi.new("WNDCLASSEX")
function main()
	hInstance = ffi.C.GetModuleHandleW(ffi.cast("LPCTSTR",nil))
	print("hInstance",hInstance)
	wcx.cbSize = ffi.sizeof("WNDCLASSEX")
	wcx.style = bor(CS_DBLCLKS,CS_HREDRAW,CS_VREDRAW)
	wcx.lpfnWndProc = WindowProcedure
--	wcx.lpfnWndProc = windowProc
	wcx.cbClsExtra = 0
	wcx.cbWndExtra = 0
	wcx.hInstance = hInstance
	wcx.hIcon = ffi.C.LoadIconW(ffi.cast("HINSTANCE",0),IDI_APPLICATION)
	wcx.hCursor = ffi.C.LoadCursorW(ffi.cast("HINSTANCE",0),IDC_ARROW)
	print("wcx.hCursor",wcx.hCursor)
	wcx.hbrBackground = ffi.cast("HBRUSH", COLOR_WINDOW+1)
	wcx.lpszMenuName = nil
	wcx.lpszClassName = wc("MainWClass")
	wcx.hIconSm = nil
	print("wcx",wcx)
	if  ffi.C.RegisterClassExW(wcx) ~= 0 then
		hwnd = ffi.C.CreateWindowExW(
			0,
			wc("MainWClass"),    -- name of window class
			wc("Hello World"),   -- title-bar string
			WS_OVERLAPPEDWINDOW, -- top-level window
			CW_USEDEFAULT,       -- default horizontal position
			CW_USEDEFAULT,       -- default vertical position
			CW_USEDEFAULT,       -- default width
			CW_USEDEFAULT,       -- default height
			nil,                 -- no owner window
			nil,                 -- use class menu
			hinstance,           -- handle to application instance
			nil);                -- no window-creation data
		print("hwnd",hwnd)
		if hwnd and ((hwnd) ~=0) then
			print("ShowWindow")
			ffi.C.ShowWindow( hwnd, SW_SHOWDEFAULT ) ;
			if true then
				print("messageloop")
				messageLoop()
				print(QueryPerformanceCounter(),"bye bye")
			else
				msg = ffi.new("MSG")
				while( ffi.C.GetMessageW( msg, nil, 0, 0 ) ~= 0) do
					-- print("MSG",msg)
					ffi.C.TranslateMessage(msg);
					ffi.C.DispatchMessageW(msg)
				end
			end
		end
	else
		print("RegisterClassExW failed")
	end
	-- ffi.C.CreateWindow(0)
end

local t1 = QueryPerformanceCounter()
main()
local t2 = QueryPerformanceCounter()
print(t2-t1)
