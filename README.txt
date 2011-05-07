RestfulMvcExample

Example of RESTful webservice with JSON representation in ASP.NET MVC 3.

This project implements 5 actions on a resource:

GET /contacts                 Gets all contacts
POST /contacts                Adds a new contact
GET /contacts/{id}            Gets a contact
PUT /contacts/{id}            Updates a contact
DELETE /contacts/{id}         Deletes a contact

To see the webservice in action:

1. Download curl from http://curl.haxx.se/dlwiz/?type=bin&os=Win32&flav=-&ver=2000%2FXP

2. Install it in any directory.

3. Run the project in Visual Studio.

4. Take note of the site URL that will open in the browser.

5. Edit the file integration-test.cmd.

6. Update the line "set SITE=" with the URL of the website, without the trailing slash.
   For example:
   set SITE=http://localhost:62983

7. Update the line "set CURL=" with the full path of the curl.exe that was installed in step 2.
   For example:
   set CURL="C:\Program Files (x86)\curl\curl.exe"

8. Save integration-test.cmd.

9. From a command prompt (cmd.exe), change to the project directory and run integration-test.cmd.
   For example:
   C:\>cd C:\Users\user.name\Documents\Visual Studio 2010\Projects\RestfulMvcExample
   C:\Users\user.name\Documents\Visual Studio 2010\Projects\RestfulMvcExample>integration-test.cmd

10. You should see an output similar to this:

RestfulMvcExample integration test
This test uses CURL to call the RESTful service

GET http://localhost:62983/
The service is running.

GET http://localhost:62983/contacts
[]

POST http://localhost:62983/contacts
{"Id":1,"Name":"Contact one","Email":"one@example.com","Phone":"555-1111","Href"
:"/contacts/1"}

POST http://localhost:62983/contacts
{"Id":2,"Name":"Contact two","Email":"two@example.com","Phone":"555-2222","Href"
:"/contacts/2"}

POST http://localhost:62983/contacts
{"Id":3,"Name":"Contact three","Email":"three@example.com","Phone":"555-3333","H
ref":"/contacts/3"}

GET http://localhost:62983/contacts
[{"Id":1,"Name":"Contact one","Email":"one@example.com","Phone":"555-1111","Href
":"/contacts/1"},{"Id":2,"Name":"Contact two","Email":"two@example.com","Phone":
"555-2222","Href":"/contacts/2"},{"Id":3,"Name":"Contact three","Email":"three@e
xample.com","Phone":"555-3333","Href":"/contacts/3"}]

PUT http://localhost:62983/contacts/2
{"Id":2,"Name":"CONTACT TWO UPDATED","Email":"two@example.com","Phone":"555-2222
","Href":"/contacts/2"}

GET http://localhost:62983/contacts/2
{"Id":2,"Name":"CONTACT TWO UPDATED","Email":"two@example.com","Phone":"555-2222
","Href":"/contacts/2"}

DELETE http://localhost:62983/contacts/1
{"message":"Contact deleted."}

GET http://localhost:62983/contacts
[{"Id":2,"Name":"CONTACT TWO UPDATED","Email":"two@example.com","Phone":"555-222
2","Href":"/contacts/2"},{"Id":3,"Name":"Contact three","Email":"three@example.c
om","Phone":"555-3333","Href":"/contacts/3"}]
