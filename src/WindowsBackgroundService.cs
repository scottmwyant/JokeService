namespace Sample.Service.WindowsService;

public sealed class WindowsBackgroundService : BackgroundService
{
    private readonly JokeService _jokeService;
    private readonly MqttService _mqttService;
    private readonly ILogger<WindowsBackgroundService> _logger;

    public WindowsBackgroundService(
        JokeService jokeService,
        MqttService mqttService,
        ILogger<WindowsBackgroundService> logger) =>
        (_jokeService, _mqttService, _logger) = (jokeService, mqttService, logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string joke = _jokeService.GetJoke();
            await _mqttService.RunAsync(joke);

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
