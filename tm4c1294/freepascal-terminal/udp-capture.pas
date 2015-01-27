uses crt, sysutils, baseunix, sockets; 

var datei : longint;

procedure printchar(zeichen : byte);
begin
  case zeichen of
     8 : write(#8, #32, #8);
    10 : writeln;
    13 : writeln;
  else
    write(chr(zeichen));
  end;  
end;

procedure start_chat(s : longint; peer : TInetSockAddr);
var input_buffer : array[0..1475] of byte;
    output_buffer : array[0..1475] of byte;

    fds : array[0..1] of tpollfd;
    ret : longint;

    bytes : integer;
    k : integer;

    key : byte;

    source_addr : TInetSockAddr;
    source_len : longint;

begin
  fds[0].fd := s;
  fds[0].events := POLLIN or POLLPRI;

  fds[1].fd := 0; // STDIN gleich mit - das spart dann eine Menge Schleifendurchläufe.
  fds[1].events := POLLIN or POLLPRI;

  repeat
    ret := fppoll(fds, 2, 1);
    if ret > 0 then
    begin

      if (fds[0].revents and (POLLIN or POLLPRI)) <> 0 then
      begin
        // textcolor(red);
        source_len := sizeof(tinetsockaddr);
        bytes := fprecvfrom(s, @input_buffer, sizeof(input_buffer), 0, @source_addr, @source_len); // Statt nil nil könnte ich hier die Absenderadresse bekommen.
        // write ('  Source port: ', ntohs(source_addr.sin_port), ' ');
        if bytes < 0 then writeln('Receive error');        
        if bytes > 0 then filewrite(datei, input_buffer, bytes); // Store capture into buffer

      end;

    end;  // ret > 0

    
    if keypressed then
    begin
      key := ord(readkey);
      // textcolor(blue);
      // printchar(key);

      // Puffer bereitmachen
      output_buffer[0] := key;
      bytes := 1;

      // Puffer abschicken
      bytes := fpsendto(s, @output_buffer, bytes, 0, @peer, sizeof(peer));
      if bytes < 0 then writeln('Send error');

      // if key = 42 then begin writeln(' Warten'); delay(10000); end; // Ok, ankommende Pakete werden gepuffert. Werden die Daten dann in eins geliefert ? Nein, Pakete bleiben getrennt.
    end;

  until key = 27;
end;


var s : longint;

    server_addr : TInetSockAddr;
    peer_addr   : TInetSockAddr;

    local_port, remote_port : word;

begin
  if paramcount <> 4 then
  begin
    writeln('Usage: udp-capture <local port> <remote host> <remote port> <file name>');
    halt;
  end;

  datei := filecreate(paramstr(4));

   local_port := strtoint(paramstr(1));
  remote_port := strtoint(paramstr(3));

  peer_addr.sin_family := AF_INET;
  peer_addr.sin_addr   := StrToNetAddr(paramstr(2));
  peer_addr.sin_port   := htons(remote_port);

  // Create UDP socket
  s := fpsocket(AF_INET, SOCK_DGRAM, 0);

  // Bind socket
  server_addr.sin_family := AF_INET;
  server_addr.sin_addr.s_addr := htonl(INADDR_ANY);
  server_addr.sin_port   := htons(local_port);

  fpbind(s, @server_addr, sizeof(server_addr));

  // Start chat
  start_chat(s, peer_addr);

  // Tidy up
  closesocket(s);

  fileclose(datei);

  // textcolor(black);
end.
