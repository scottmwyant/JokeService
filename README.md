# WindowsService
Sample code for a Windows Service in .NET6

Based on the tutorial found at 

https://docs.microsoft.com/en-us/dotnet/core/extensions/windows-service

## Building the source code

A default build task has been configured for VS Code.  Simply run the `dotnet publish` task.

## Running the service

Use the Windows Service Control Manager, *sc.exe*

Install the service

`sc.exe create ".NET Joke Service" binpath="C:\Path\To\Sample.Service.exe"`

Start the service

`sc.exe start ".NET Joke Service"`

View logs

Use `Event Viewer > Windows Logs > Application`.  You should see a log entry with a severity of `Warning` and a source of `Sample.Service`.  This sample code is designed to log a random joke every minute.

Stop the service

`sc.exe stop ".NET Joke Service"`

Delete the service

`sc.exe delete ".NET Joke Service"`
