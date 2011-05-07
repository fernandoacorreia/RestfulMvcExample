@echo off
echo RestfulMvcExample integration test
echo This test uses CURL to call the RESTful service
echo:

REM Set the site's base URL
set SITE=http://localhost:62983

REM Set to the full path of curl.exe
REM Download curl from http://curl.haxx.se/dlwiz/?type=bin&os=Win32&flav=-&ver=2000%2FXP
set CURL="C:\Program Files (x86)\curl\curl.exe"

echo GET %SITE%/
%CURL% %SITE%/
echo:
echo:

echo GET %SITE%/contacts
%CURL% %SITE%/contacts
echo:
echo:

echo POST %SITE%/contacts
%CURL% --header "Content-Type: application/json" --data "{\"Id\":1,\"Name\":\"Contact one\",\"Email\":\"one@example.com\",\"Phone\":\"555-1111\"}" %SITE%/contacts
echo:
echo:

echo POST %SITE%/contacts
%CURL% --header "Content-Type: application/json" --data "{\"Id\":2,\"Name\":\"Contact two\",\"Email\":\"two@example.com\",\"Phone\":\"555-2222\"}" %SITE%/contacts
echo:
echo:

echo POST %SITE%/contacts
%CURL% --header "Content-Type: application/json" --data "{\"Id\":3,\"Name\":\"Contact three\",\"Email\":\"three@example.com\",\"Phone\":\"555-3333\"}" %SITE%/contacts
echo:
echo:

echo GET %SITE%/contacts
%CURL% %SITE%/contacts
echo:
echo:

echo PUT %SITE%/contacts/2
%CURL% -X PUT --header "Content-Type: application/json" --data "{\"Id\":2,\"Name\":\"CONTACT TWO UPDATED\",\"Email\":\"two@example.com\",\"Phone\":\"555-2222\"}" %SITE%/contacts/2 
echo:
echo:

echo GET %SITE%/contacts/2
%CURL% %SITE%/contacts/2
echo:
echo:

echo DELETE %SITE%/contacts/1
%CURL% -X DELETE %SITE%/contacts/1
echo:
echo:

echo GET %SITE%/contacts
%CURL% %SITE%/contacts
echo:
echo:

pause
