# SignalRDemo

Simple demo of signalr

Includes completely separate Client and Server projects

Runs on .net core 2.1.0-preview1-final so buyer beware ([download SDK here](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview1))

Server sets Cors header 'AllowAny' for every type of request from anyone

## Dev dependencies
install [npm/node](https://nodejs.org/en/)

install [.net core 2.1.0-preview1-final SDK](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview1)

uses localdb (double check connecting string is good for you in Server/appsettings.Development.json)

## How to get it running
* pull/download (duh)
* cd to Client
* `dotnet restore`
* `npm i` (restore packages)
* `npm run Default` (a gulp task, generates css from sass; copies fonts)
* cd to Server
* `dotnet restore`
* `dotnet ef database update` (connection string is in appsettings.Development.json, named 'Default')

### If you don't have Visual Studio Code
If you don't have vscode just cd to server and `dotnet run --environment "Development"`, then cd to client and `dotnet run --environment "Development"`; client is [http://localhost:5000] by default.

### If you have Visual Studio Code
There are 3 launch configurations for vscode

Use 'Launch client and server' config to spawn server on loopback:5001 and client on loopback:5000; browser opens automatically (can be changed in appsettings)