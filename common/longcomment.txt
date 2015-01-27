
: (* ( -- ) \ Long comment

begin
  token  \ Get next token
  dup 0= if 2drop cr query token then  \ If length of token is zero, end of line is reached. Fetch new line. Fetch new token.
  s" *)" compare  \ Search for *)
until

immediate 0-foldable ; 
