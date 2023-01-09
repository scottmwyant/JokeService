using Serilog;
using Sample.Service.WindowsService;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET Joke Service";
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<JokeService>();
        services.AddHostedService<WindowsBackgroundService>();
    })
    .UseSerilog((context, loggerConfiguration) => loggerConfiguration
            .WriteTo.File(
                path: Path.Join(context.HostingEnvironment.ContentRootPath, "log.txt"),
                rollOnFileSizeLimit: true,
                fileSizeLimitBytes: 1000000,
                retainedFileCountLimit: 2
            )
    )
    .Build();

await host.RunAsync();
