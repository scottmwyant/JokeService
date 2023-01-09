# WindowsService
Sample code for a Windows Service in .NET6

Based on the tutorial found at 

https://docs.microsoft.com/en-us/dotnet/core/extensions/windows-service

## Building the source code

A default build task has been configured for VS Code.  Simply run the `publish` task.  Once the project is built, it has to be `installed` as a service and started.  Once it's installed, it must be stopped before building again.  After rebuilding, the service can be restarted and it will use the rebuilt version.

## Next steps:

1. Combine the two samples.  Make a service that includes an MQTT client, send the jokes to the broker and to the log file.
    Options might include the host, port, username, and password for the mqtt broker. 

2. Use the options pattern (link below) to get configuration values to the right place.

- https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration-providers?source=recommendations
- https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration?source=recommendations
- https://learn.microsoft.com/en-us/dotnet/core/extensions/options
- https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder?view=dotnet-plat-ext-7.0

Use appsettings.json for SeriLog

- https://www.nuget.org/packages/Serilog.Settings.Configuration/3.5.0-dev-00370

Use this to tie Serilog to the host

- https://www.nuget.org/packages/Serilog.Extensions.Hosting
- https://stackoverflow.com/questions/57070972/how-to-add-a-serilog-logger-to-a-generichost-project-in-c-sharp

Use this to log to a rolling file

- https://www.nuget.org/packages/Serilog.Sinks.File/5.0.1-dev-00947