local bit=require("bit")

local function printf(fmt,...)
  print(string.format(fmt,...))
end

function digit(n)
  local c=""
  if(n > 9) then
    c = string.char(n-10+("A"):byte())
  else
    c = string.char(n + ("0"):byte())
  end
  print("digit", n,c)
  return c
end


-- convert number n to string with base
function toBase(n,b,places,group)
  group = group or 4
  places = places or 0
  local k = 1
  local digs =""
  local digits = 0
  repeat
    local m = n % b
    digs = digit(m) .. digs
    digits = digits + 1
    n = (n - m) / b
    if k == group and (n~=0 or digits < places) then
      digs = " " .. digs
      k = 1
    else
      k = k + 1
    end
  until n == 0 and digits >= places
  return digs
end

function format(s)
  return string.gsub(s, "(.*)(....)$","%2 %1 ")
end


local nums = {
 47,
 48,
 49,
 50,
 88,
 89,
111,
112,
}

local numbits=math.ceil(math.log(#nums)/math.log(2))
print("numbits",numbits)
local mask=bit.lshift(1,numbits)-1
print("mask",mask)
print("mask",mask)
local checkMask = bit.lshift(1,#nums)-1
print("checkMask",checkMask)
local function searchHash()
  local n=0
  for k=0,1000 do
    for i=1,0xffffffff do
        if n >= 10000000-1 then
          print( i,k)
          n=0
        else
          n=n+1
        end 
        local chk=0
        for j=1,#nums do
          local r = bit.lshift(1,bit.band((nums[j]+k)*i,mask))
          chk = bit.bor(r,chk)
        end
    --    printf("chk %X mask %x",chk,mask)
        if chk == checkMask then
          printf("hash factor:0x%X sum 0x%X",i, k)
          return
        end
    end
  end
end

-- searchHash()
